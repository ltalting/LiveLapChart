using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveLapTime
{
    public class Driver
    {
        public string carNo;
        public string bestLap;

        public Driver(string carNo, string bestLap)
        {
            this.carNo = carNo;
            this.bestLap = bestLap;
        }

        public void setCarNo(string carNo)
        {
            this.carNo = carNo;
        }

        public void setBestLap(string bestLap)
        {
            this.bestLap = bestLap;
        }

        public string getCarNo()
        {
            return this.carNo;
        }

        public string getBestLap()
        {
            return this.bestLap;
        }
    }
}