using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorPoly
{
    public abstract class Sensor
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public virtual string Unit
        {
            get => "";
            private set { }
        }

        public abstract int[] GetAcceptableValues();

        protected Sensor(string name, string description, string url, decimal lat, decimal lon)
        {
            Name = name;
            Description = description;
            URL = url;
            Latitude = lat;
            Longitude = lon;
        }
    }
}
