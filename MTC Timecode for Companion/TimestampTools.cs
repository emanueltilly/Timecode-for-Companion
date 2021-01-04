using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTC_Timecode_for_Companion
{
    class TimestampTools
    {
        private static int localFPS = 25;
        public static void setFPS(int fps) { localFPS = fps; }
        public static string timecodeToString(int[] timecode)
        {
            if (timecode.Length != 4) { Console.WriteLine("Error converting timecode to string! Wrong array length."); return "00:00:00:00"; }

            try
            {
                string hh = ((timecode[0] < 10) ? ("0" + timecode[0].ToString()) : timecode[0].ToString());
                string mm = ((timecode[1] < 10) ? ("0" + timecode[1].ToString()) : timecode[1].ToString());
                string ss = ((timecode[2] < 10) ? ("0" + timecode[2].ToString()) : timecode[2].ToString());
                string ff = ((timecode[3] < 10) ? ("0" + timecode[3].ToString()) : timecode[3].ToString());
                string finalString = (hh + ":" + mm + ":" + ss + ":" + ff);
                return finalString;
            } catch (Exception e)
            {
                Console.WriteLine("Error converting timecode to string!");
                Console.WriteLine(e);
                return "00:00:00:00";
            }
            
        }

        public static int convertTimestampToFrames(int[] timecode)
        {
            int result = 0;

            //Hour
            result = (result + (timecode[0] * (localFPS * 3600)));
            //Minute
            result = (result + (timecode[1] * (localFPS * 60)));
            //Second
            result = (result + (timecode[2] * localFPS));
            //Frame
            result = (result + timecode[3]);

            return result;
        }

        public static Int32 getUnixTimestamp()
        {
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return unixTimestamp;
        }
    }
}
