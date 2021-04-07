using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;


namespace MTC_Timecode_for_Companion
{
    [XmlRoot("TimecodeEvent")]
    public class TimecodeEvent
    {
        private int hour = 0;
        private int minute = 0;
        private int second = 0;
        private int frame = 0;
        private int realFrame = 0;
        private string eventName = "Timecode Event";
        private int page = 1;
        private int bank = 1;
        private bool enabled = true;
        private bool executed = false;
        private bool oneShot = false;
        private Int32 lastExecution = 0;

        public TimecodeEvent()
        {
        }

        [XmlAttribute(DataType = "int", AttributeName = "Hour")]
        public int Hour
        {
            get { return hour; }
            set { hour = value; UpdateRealFrame(); }
        }
        [XmlAttribute(DataType = "int", AttributeName = "Minute")]
        public int Minute
        {
            get { return minute; }
            set { minute = value; UpdateRealFrame(); }
        }
        [XmlAttribute(DataType = "int", AttributeName = "Second")]
        public int Second
        {
            get { return second; }
            set { second = value; UpdateRealFrame(); }
        }
        [XmlAttribute(DataType = "int", AttributeName = "Frame")]
        public int Frame
        {
            get { return frame; }
            set { frame = value; UpdateRealFrame(); }
        }


        [XmlAttribute(DataType = "string", AttributeName = "EventName")]
        public string EventName
        {
            get { return eventName; }
            set { eventName = value; }
        }
        [XmlAttribute(DataType = "int", AttributeName = "Page")]
        public int Page
        {
            get { return page; }
            set { page = value; }
        }
        [XmlAttribute(DataType = "int", AttributeName = "Bank")]
        public int Bank
        {
            get { return bank; }
            set { bank = value; }
        }
        [XmlAttribute(DataType = "boolean", AttributeName = "Enabled")]
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        [XmlAttribute(DataType = "boolean", AttributeName = "Executed")]
        public bool Executed
        {
            get { return executed; }
            set { executed = value; }
        }
        [XmlAttribute(DataType = "int", AttributeName = "RealFrame")]
        public int RealFrame
        {
            get { return realFrame; }
            set { }
            
        }
        [XmlAttribute(DataType = "boolean", AttributeName = "OneShot")]
        public bool OneShot
        {
            get { return oneShot; }
            set { oneShot = value; executed = false; }
        }
        //[XmlAttribute(DataType = "Int32", AttributeName = "LastExecution")]
        public Int32 LastExecution
        {
            get { return lastExecution; }
            set { lastExecution = value; }
        }

        public void UpdateRealFrame()
        {
            int[] timestamp = new int[4] { hour, minute, second, frame };
            realFrame = TimestampTools.ConvertTimestampToFrames(timestamp);
        }

        public void ResetExecuted()
        {
            executed = false;
        }

    }
}
