using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveLapTime
{
    public class Lap
    {
        public int lapNumber;
        public List<string> positionsList;
        public List<string> lappedCars;
        public string flagColor;
        public List<string> pittedCars;

        public Lap(int lapNum, List<string> positions, List<string> lappedCars, string flagColor, List<string> pittedCars)
        {
            this.lapNumber = lapNum;
            this.positionsList = positions;
            this.lappedCars = lappedCars;
            this.flagColor = flagColor;
            this.pittedCars = pittedCars;
        }

        /* Set statements */
        public void setLapNumber(int lap)
        {
            this.lapNumber = lap;
        }

        public void setPositions(List<string> positions)
        {
            this.positionsList = positions;
        }

        public void setLappedCars(List<string> lappedCars)
        {
            this.lappedCars = lappedCars;
        }

        public void setFlagColor(string flagColor)
        {
            this.flagColor = flagColor;
        }

        public void setPittedCars(List<string> pittedCars)
        {
            this.pittedCars = pittedCars;
        }

        /* Get statements */
        public int getLapNumber()
        {
            return this.lapNumber;
        }

        public List<string> getPositions()
        {
            return this.positionsList;
        }

        public List<string> getLappedCars()
        {
            return this.lappedCars;
        }

        public string getFlagColor()
        {
            return this.flagColor;
        }

        public List<string> getPittedCars()
        {
            return this.pittedCars;
        }
    }
}