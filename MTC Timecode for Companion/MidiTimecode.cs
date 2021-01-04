using System;
using System.Linq;
using Melanchall.DryWetMidi.Devices;
using Melanchall.DryWetMidi.Core;

class MidiTimecode
{
    // Get Device List
    public static InputDevice[] getInputDevices() { return InputDevice.GetAll().ToArray(); }

    // Public Settings
    public InputDevice inputDevice;
    public double inputFPS;
    public double inputOffset;
    public TimeSnap timeSnap;

    // Time Data
    byte flsb, fmsb, slsb, smsb, mlsb, mmsb, hlsb, hmsb;
    bool[] valuesSet = { false, false, false, false, false, false, false, false };

    public MidiTimecode() { timeSnap = new TimeSnap(0, 0); }

    // Initialize Listener
    public void initialize() // Run After Ever Settings Change And On Start
    {
        if (inputDevice != null && inputDevice.IsListeningForEvents)
        {
            inputDevice.StopEventsListening();
            timeSnap = new TimeSnap(0d);
        }

        timeSnap = new TimeSnap(inputFPS, inputOffset);
        inputDevice.EventReceived += InputDevice_EventReceived;
        inputDevice.StartEventsListening();
    }

    private void InputDevice_EventReceived(object sender, MidiEventReceivedEventArgs e)
    {
        if (e.Event.GetType() == (new MidiTimeCodeEvent()).GetType())
        {
            MidiTimeCodeEvent ev = (MidiTimeCodeEvent)e.Event;
            if (ev.Component == MidiTimeCodeComponent.FramesLsb) { flsb = ev.ComponentValue; valuesSet[0] = true; }
            if (ev.Component == MidiTimeCodeComponent.FramesMsb) { fmsb = ev.ComponentValue; valuesSet[1] = true; }
            if (ev.Component == MidiTimeCodeComponent.SecondsLsb) { slsb = ev.ComponentValue; valuesSet[2] = true; }
            if (ev.Component == MidiTimeCodeComponent.SecondsMsb) { smsb = ev.ComponentValue; valuesSet[3] = true; }
            if (ev.Component == MidiTimeCodeComponent.MinutesLsb) { mlsb = ev.ComponentValue; valuesSet[4] = true; }
            if (ev.Component == MidiTimeCodeComponent.MinutesMsb) { mmsb = ev.ComponentValue; valuesSet[5] = true; }
            if (ev.Component == MidiTimeCodeComponent.HoursLsb) { hlsb = ev.ComponentValue; valuesSet[6] = true; }
            if (ev.Component == MidiTimeCodeComponent.HoursMsbAndTimeCodeType) { hmsb = ev.ComponentValue; valuesSet[7] = true; }

            if (valuesSet.All(a => a))
            {
                int frames = Convert.ToInt32(Convert.ToString(fmsb, 2).PadLeft(4, '0') + Convert.ToString(flsb, 2).PadLeft(4, '0'), 2);
                int seconds = Convert.ToInt32(Convert.ToString(smsb, 2).PadLeft(4, '0') + Convert.ToString(slsb, 2).PadLeft(4, '0'), 2);
                int minutes = Convert.ToInt32(Convert.ToString(mmsb, 2).PadLeft(4, '0') + Convert.ToString(mlsb, 2).PadLeft(4, '0'), 2);
                int hours = Convert.ToInt32(Convert.ToString(hlsb, 2).PadLeft(8, '0'), 2);
                timeSnap.update(hours, minutes, seconds, frames);
                for (int i = 0; i < valuesSet.Length; i++) valuesSet[i] = false;
            }
        }
    }
}

class TimeSnap
{
    private double fps = 0;
    private double timecode = 0d;
    private double updateTime = 0d;
    private double offset = 0d;
    private bool cleared = true;
    private bool running = true;
    private double pausedValue = 0d;

    public TimeSnap(double fps, double offset = 0d)
    {
        this.fps = fps; // Set The TimeSnap FPS
        this.offset = offset; // Set The TimeSnap Offset
    }

    public void update(double hours, double minutes, double seconds, double frames)
    {
        double updatedTc =
            hours * 60d * 60d * 1000d +     // Convert The Hours    Into Milliseconds
            minutes * 60d * 1000d +         // Convert The Minutes  Into Milliseconds
            seconds * 1000d +               // Convert The Seconds  Into Milliseconds
            frames * (1000d / fps)          // Convert The Frames   Into Milliseconds
        ;
        double tcDiff = Math.Abs(Math.Floor(timecode - updatedTc)); // Timecode Difference From Last Updated Value
        if (tcDiff != 933 && tcDiff != 466 && tcDiff != 400)
        {
            double actualTcDiff = Math.Abs(updatedTc - getNowTime().TotalMilliseconds); // Timecode Difference From Current Guessed Time
            if (actualTcDiff > 50d) // Only Allow Updates Over 50ms
            {
                timecode = updatedTc; // Set The Updated Timecode
                cleared = false; // Set Cleared To False
            }
            updateTime = milliTime(); // Set The Update Time
        }
    }

    public void update(TimeSnap ts)
    {
        this.fps = ts.fps;
        this.timecode = ts.timecode;
        this.updateTime = ts.updateTime;
        this.offset = ts.offset;
        this.cleared = ts.cleared;
    }

    public void setOffset(double offset)
    {
        this.offset = offset;
    }

    public void toggleCounting(bool run = false)
    {
        running = run;
        pausedValue = timecode;
    }

    // Predicted time is calculated from last update. False gives last update.
    public TimeSpan getNowTime(bool predicted = true) // HH:MM:SS:MS
    {
        if (!running) return TimeSpan.FromMilliseconds(pausedValue);
        if (cleared) return TimeSpan.FromMilliseconds(0);
        return TimeSpan.FromMilliseconds(timecode + (predicted ? (milliTime() - updateTime) + offset : 0));
    }

    // Predicted time is calculated from last update. False gives last update.
    public int[] getNowTimecode(bool predicted = true) // HH:MM:SS:FF
    {
        if (cleared) return new int[] { 0, 0, 0, 0 };
        TimeSpan now = getNowTime(predicted);
        return new int[]
        {
            now.Hours, now.Minutes, now.Seconds,
            (int)Math.Floor(now.Milliseconds / (1000 / fps))
        };
    }

    // Get Time Since Last Update
    public TimeSpan getLastUpdate()
    {
        return TimeSpan.FromMilliseconds(milliTime() - updateTime);
    }

    private double milliTime() // Returns The Time Since First Of January 2020
    { return (DateTime.Now - (new DateTime(2020, 1, 1, 0, 0, 0, 0))).TotalMilliseconds; }
}