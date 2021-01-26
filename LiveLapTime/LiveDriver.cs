using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveLapTime
{
    public class LiveDriver
    {
        int carNo;
        int currentLap;
        int currentPosition;
        int lastPit;
        string flagStatus;
        int bestLapX;
        int bestLapY;
        int secBestLapX;
        int secBestLapY;
        System.Drawing.Color secBestLapColor;

        public LiveDriver(int carNo, int currentLap, int currentPosition)
        {
            this.carNo = carNo;
            this.currentLap = currentLap;
            this.currentPosition = currentPosition;
        }

        /* Get statements */
        public int getCarNo()
        {
            return this.carNo;
        }

        public int getCurrentLap()
        {
            return this.currentLap;
        }

        public int getCurrentPosition()
        {
            return this.currentPosition;
        }

        public int getLastPit()
        {
            return this.lastPit;
        }

        public string getFlagStatus()
        {
            return this.flagStatus;
        }

        public int getBestLapX()
        {
            return this.bestLapX;
        }

        public int getBestLapY()
        {
            return this.bestLapY;
        }

        public int getSecBestLapX()
        {
            return this.secBestLapX;
        }

        public int getSecBestLapY()
        {
            return this.secBestLapY;
        }

        public System.Drawing.Color getSecBestLapColor()
        {
            return this.secBestLapColor;
        }

        /* Set statements */
        public void setCurrentLap(int currentLap)
        {
            this.currentLap = currentLap;
        }

        public void setCurrentPosition(int currentPosition)
        {
            this.currentPosition = currentPosition;
        }

        public void setLastPit(int lastPit)
        {
            this.lastPit = lastPit;
        }

        public void setFlagStatus(string flagStatus)
        {
            this.flagStatus = flagStatus;
        }

        public void setBestLapX(int bestLapX)
        {
            this.bestLapX = bestLapX;
        }

        public void setBestLapY(int bestLapY)
        {
            this.bestLapY = bestLapY;
        }

        public void setSecBestLapX(int secBestLapX)
        {
            this.secBestLapX = secBestLapX;
        }

        public void setSecBestLapY(int secBestLapY)
        {
            this.secBestLapY = secBestLapY;
        }

        public void setSecBestLapColor(System.Drawing.Color secBestLapColor)
        {
            this.secBestLapColor = secBestLapColor;
        }
    }
}