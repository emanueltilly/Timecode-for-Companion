﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Melanchall.DryWetMidi.Devices;


namespace MTC_Timecode_for_Companion
{
    public partial class Form1 : Form
    {
        MidiTimecode mtc;

        ProjectData data = new ProjectData();

        TimecodeSmoother tcSmooth = new TimecodeSmoother();

        TimecodeEvent nextEvent = new TimecodeEvent();

        private bool toggleTC = true;

        private int[] liveTC = new int[4] { 0, 0, 0, 0 };
        private bool liveTCrolling = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nextEvent.Hour = 99;
            nextEvent.Minute = 99;
            nextEvent.Second = 99;
            nextEvent.Frame = 99;
            nextEvent.Enabled = false;

            mtc = new MidiTimecode();
            var devices = MidiTimecode.getInputDevices();
            foreach (InputDevice device in devices)
                inputdevice.Items.Add(device.Name);



            //Create dummy objects
            /*int loop = 0;
            while (loop < 20)
            {
                data.TimecodeEventList.Add(new TimecodeEvent());
                
                loop++;
            }*/

            loadGUIfromData();

        }

        private void loadGUIfromData()
        {
            reloadDataGridView();
            fpsDropdown.SelectedIndex = data.fpsDropdownIndex;
            
        }

        private void reloadDataGridView()
        {
            //Link list to data grid view
            var source = new BindingSource();
            source.DataSource = data.TimecodeEventList;
            dataGridView1.DataSource = source;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void tcTimer_Tick(object sender, EventArgs e)
        {
            //Update the local time variable
            liveTCrolling = (mtc.timeSnap.getLastUpdate().TotalSeconds < 1.5d);
            if (liveTCrolling == true) { liveTC = tcSmooth.updateLiveTC(mtc.timeSnap.getNowTimecode(true)); }

            int liveRealFrame = TimestampTools.convertTimestampToFrames(liveTC);

            //See if any lines can be executed
            foreach (TimecodeEvent evnt in data.TimecodeEventList)
            {
                if (evnt.Executed != true && evnt.Enabled == true && data.TimecodeEventList.Count > 0)
                {
                    //If event is on this frame or has been missed in the last 10 frames
                    if (evnt.RealFrame == liveRealFrame || (evnt.RealFrame < liveRealFrame && evnt.RealFrame > (liveRealFrame - 10)))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("EXEC EVENT " + evnt.EventName);
                        evnt.Executed = true;
                    }
                }
            }


            //GUI
            timecode_lbl.Text = TimestampTools.timecodeToString(liveTC);
            timecode_lbl.ForeColor = liveTCrolling ? Color.Lime : Color.DarkRed;
            
            
            
        }

        private void toggleTimecodeButton_Click(object sender, EventArgs e)
        {
            toggleTC = (toggleTC ? false : true);
            mtc.timeSnap.toggleCounting(toggleTC);
        }

        private void saveProjectButton_Click(object sender, EventArgs e)
        {
            
        }

        private void openProjectButton_Click(object sender, EventArgs e)
        {
         
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog
            {
                RestoreDirectory = true,
                Title = "Save Project",
                DefaultExt = "xml",
                Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
            };
            //SaveFileDialog1.ShowDialog();

            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //SAVE TO FILE
                data.SaveToFile(SaveFileDialog1.FileName);
            }
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                Title = "Open Project",
                Filter = "Xml Files (*.xml)|*.xml" + "|" +
                            "All Files (*.*)|*.*"
            };
            if (openDialog.ShowDialog() == DialogResult.OK)
            {

                data = ProjectData.LoadFromFile(openDialog.FileName);
                loadGUIfromData();

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void inputdevice_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            toggleTC = (toggleTC ? false : true);
            mtc.timeSnap.toggleCounting(toggleTC);
        }

        private void fpsDropdown_TextChanged(object sender, EventArgs e)
        {
            data.fpsDropdownIndex = fpsDropdown.SelectedIndex;
            TimestampTools.setFPS(int.Parse(fpsDropdown.Text));
            
        }

        private void applyTCbutton_Click(object sender, EventArgs e)
        {
            if (inputdevice.SelectedIndex >= 0 && fpsDropdown.SelectedIndex >= 0)
            {
                recalculateRealFrameForList();
                resetExecutedForList();

                


                mtc.inputDevice = MidiTimecode.getInputDevices()[inputdevice.SelectedIndex];
                mtc.inputFPS = int.Parse(fpsDropdown.Text);
                mtc.inputOffset = 0;
                mtc.initialize();
                inputdevice.Enabled = false;
                fpsDropdown.Enabled = false;
                applyTCbutton.Enabled = false;
                toggleTimecodeButton.Enabled = true;

                tcSmooth.initialize(data, int.Parse(fpsDropdown.Text));

                tcTimer.Interval = tcSmooth.fpsToMs(int.Parse(fpsDropdown.Text));
                tcTimer.Enabled = true;
            }
        }

        private void recalculateRealFrameForList()
        {
            foreach (TimecodeEvent e1 in data.TimecodeEventList)
            {
                e1.updateRealFrame();
                
                
            }
        }
        private void resetExecutedForList()
        {
            foreach (TimecodeEvent e2 in data.TimecodeEventList)
            {
                e2.resetExecuted();
               
            }
        }
    }
}