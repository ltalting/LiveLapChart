using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveLapTime
{
    public class LiveRestore
    {
        int carNoRestore;
        int restoreBestX;
        int restoreBestY;
        System.Drawing.Color restoreBestColor;

        public LiveRestore(int carNoRestore, int restoreBestX, int restoreBestY, System.Drawing.Color restoreBestColor)
        {
            this.carNoRestore = carNoRestore;
            this.restoreBestX = restoreBestX;
            this.restoreBestY = restoreBestY;
            this.restoreBestColor = restoreBestColor;
        }

        public int getCarNoRestore()
        {
            return this.carNoRestore;
        }

        public int getRestoreBestX()
        {
            return this.restoreBestX;
        }

        public int getRestoreBestY()
        {
            return this.restoreBestY;
        }

        public System.Drawing.Color getRestoreBestColor()
        {
            return this.restoreBestColor;
        }

        public void setCarNoRestore(int carNoRestore)
        {
            this.carNoRestore = carNoRestore;
        }

        public void setRestoreBestX(int restoreBestX)
        {
            this.restoreBestX = restoreBestX;
        }

        public void setRestoreBestY(int restoreBestY)
        {
            this.restoreBestY = restoreBestY;
        }

        public void setRestoreBestColor(System.Drawing.Color restoreBestColor)
        {
            this.restoreBestColor = restoreBestColor;
        }
    }
}
