using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorPoly
{
    class Temperature : Sensor
    {
        public Temperature(string name, string description, string url, decimal lat, decimal lon) : base(name, description, url, lat, lon)
        {
        }

        public override string Unit => "°C";

        public override int[] GetAcceptableValues()
        {
            return new int[2];
        }
    }
}
