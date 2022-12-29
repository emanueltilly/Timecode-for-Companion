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
        
        public static void SetFPS(string fps) { 
        
            switch(fps)
            {
                case "23.976ND":
                    localFPS= 24;
                    break;
                case "24":
                    localFPS = 24;
                    break;
                case "25":
                    localFPS = 25;
                    break;
                case "29.97DF":
                    localFPS = 30;
                    break;
                case "29.97ND":
                    localFPS = 30;
                    break;
                case "30":
                    localFPS = 30;
                    break;
            }

        }
        public static string TimecodeToString(int[] timecode)
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

        public static int ConvertTimestampToFrames(int[] timecode)
        {
            int result = 0;

            //Hour
            result += (timecode[0] * (localFPS * 3600));
            //Minute
            result += (timecode[1] * (localFPS * 60));
            //Second
            result += (timecode[2] * localFPS);
            //Frame
            result += timecode[3];

            return result;
        }

        public static Int32 GetUnixTimestamp()
        {
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return unixTimestamp;
        }
    }
}
