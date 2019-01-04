﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate_v2
{
    public class PowerConsumptionSensor:Sensor
    {
        private decimal minValue;
        private decimal maxValue;

        public PowerConsumptionSensor(string name, string url, string description, decimal latitude, decimal longitude, bool followed,decimal minValue, decimal maxValue)
            : base(name, url, description, latitude, longitude,followed)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public PowerConsumptionSensor() : base()
        {
            MinValue = 0;
            MaxValue = 0;
        }

        public PowerConsumptionSensor(PowerConsumptionSensor sensor) : base(sensor)
        {
            MinValue = sensor.MinValue;
            MaxValue = sensor.MaxValue;
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
