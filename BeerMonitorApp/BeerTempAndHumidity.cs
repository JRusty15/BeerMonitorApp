using System;

namespace BeerMonitorApp
{
    public class BeerTempAndHumidity
    {
        public BeerTempAndHumidity()
        {
        }

        public double Temperature { get; set;  }
        public double Humidity { get; set; }
        public string EntryTimestamp { get; set; }
    }

    public class BeerTempChartData
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public DateTime EntryTimestamp { get; set; }
    }
}
