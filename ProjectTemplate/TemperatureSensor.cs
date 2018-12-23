using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate
{
    public class TemperatureSensor : Sensor
    {
        private double minValue;
        private double maxValue;

        public TemperatureSensor(string name, string url, string description, double latitude, double longitude, bool followed, double minValue, double maxValue) 
            : base(name, url, description, latitude, longitude,followed)
        {
            MinValue = minValue;
            MaxValue = MaxValue;
        }

        public TemperatureSensor() : base()
        {
            MinValue = 0;
            MaxValue = 0;
        }

        public double MaxValue
        {
            get { return maxValue; }
            set
            {
                if (maxValue != value)
                {
                    maxValue = value;
                    NotifyPropertyChanged("MaxValue");
                }
            }
        }

        public double MinValue
        {
            get { return minValue; }
            set
            {
                if (minValue != value)
                {
                    minValue = value;
                    NotifyPropertyChanged("MinValue");
                }
            }
        }
    }
}
