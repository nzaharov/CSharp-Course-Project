﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate
{
    public class NoiseSensor:Sensor
    {
        private decimal minValue;
        private decimal maxValue;

        public NoiseSensor(string name, string url, string description, decimal latitude, decimal longitude,bool followed, decimal minValue, decimal maxValue)
            : base(name, url, description, latitude, longitude,followed)
        {
            MinValue = minValue;
            MaxValue = MaxValue;
        }

        public NoiseSensor() : base()
        {
            MinValue = 0;
            MaxValue = 0;
        }

        public decimal MaxValue
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

        public decimal MinValue
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
