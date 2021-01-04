using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MTC_Timecode_for_Companion
{
    class TimecodeSmoother
    {
        private int[,] historyStamp = new int[5, 4];
        private int prevSec = 999;
        private Timer frameTimer = new Timer(1000);
        private int localFPS = 25;
        private int currentFrame = 0;

        public void initialize(ProjectData data, int fps)
        {
            historyStamp = Fill2DArray(historyStamp);
            localFPS = fps;
            frameTimer.AutoReset = true;
            frameTimer.Interval = fpsToMs(fps);
            frameTimer.Enabled = true;
            frameTimer.Elapsed += FrameTimer_Elapsed;
        }

        private void FrameTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            
            if ((currentFrame + 1) < localFPS) { currentFrame++;  }
        }

        public int[] updateLiveTC(int[] sourceTC)
        {
            //Check for big changes
            if ((sourceTC[0] > (historyStamp[4,0] + 2)) || (sourceTC[0] < (historyStamp[4, 0] - 2))) { historyStamp = Fill2DArray(historyStamp); }
            if ((sourceTC[1] > (historyStamp[4, 1] + 2)) || (sourceTC[1] < (historyStamp[4, 1] - 2))) { historyStamp = Fill2DArray(historyStamp); }
            if ((sourceTC[2] > (historyStamp[4, 2] + 10)) || (sourceTC[2] < (historyStamp[4, 2] - 10))) { historyStamp = Fill2DArray(historyStamp); }


            int[] result = new int[4] { 0, 0, 0, 0 };

            //Hour
            if (sourceTC[0] == 0 || (sourceTC[0] > historyStamp[4, 0] && sourceTC[0] > historyStamp[3, 0] && sourceTC[0] > historyStamp[2, 0] && sourceTC[0] > historyStamp[1, 0] && sourceTC[0] > historyStamp[0, 0]))
            {
                result[0] = sourceTC[0];
            } else
            {
                result[0] = historyStamp[4, 0];
            }
            //Minute
            if (sourceTC[1] == 0 || (sourceTC[1] > historyStamp[4, 1] && sourceTC[1] > historyStamp[3, 1] && sourceTC[1] > historyStamp[2, 1] && sourceTC[1] > historyStamp[1, 1] && sourceTC[1] > historyStamp[0, 1]))
            {
                result[1] = sourceTC[1];
            }
            else
            {
                result[1] = historyStamp[4, 1];
            }
            //Second
            if (sourceTC[2] == 0 || (sourceTC[2] > historyStamp[4, 2] && sourceTC[2] > historyStamp[3, 2] && sourceTC[2] > historyStamp[2, 2] && sourceTC[2] > historyStamp[1, 2] && sourceTC[2] > historyStamp[0, 2]))
            {
                result[2] = sourceTC[2];
                if (result[2] != prevSec) { prevSec = result[2]; currentFrame = 0; }
            }
            else
            {
                result[2] = historyStamp[4, 2]; 
            }
            //Frame
            result[3] = currentFrame;



            //Add new value to history
            addToHistoryStamp(result);

            return result;
        }

        private void addToHistoryStamp(int[] newTC)
        {
            int rowCount = 0;
            int colCount = 0;

            while (rowCount < 5)
            {
                while(colCount < 4 && rowCount != 4)
                {
                    historyStamp[rowCount, colCount] = historyStamp[(rowCount + 1), colCount];
                    colCount++;
                }
                while (colCount < 4 && rowCount == 4)
                {
                    historyStamp[rowCount, colCount] = newTC[colCount];
                    colCount++;
                }
                
                colCount = 0;
                rowCount++;
            }

        }

        public int fpsToMs(int fps)
        {
            int result = (int)Math.Floor((decimal)1000 / (decimal)fps);
            return result;
        }
    private int[,] Fill2DArray(int[,] arr)
        {
            int numRows = arr.GetLength(0);
            int numCols = arr.GetLength(1);

            for (int i = 0; i < numRows; ++i)
            {
                for (int j = 0; j < numCols; ++j)
                {
                    arr[i, j] = 1;
                }
            }

            return arr;
        }
    }

   
}
