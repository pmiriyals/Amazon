using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrivalsMonitorObserverPattern
{
    public class BaggageInfoModel
    {
        public int flightID { get; set; }
        public string origin { get; set; }
        public int location { get; set; }
        public BaggageInfoModel(int flightID, string origin, int loc)
        {
            this.flightID = flightID;
            this.origin = origin;
            this.location = loc;
        }
    }
}
