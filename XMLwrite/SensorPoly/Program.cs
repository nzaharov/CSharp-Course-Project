using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorPoly
{
    class Program
    {
        static void Main(string[] args)
        {
            Sensor[] sensors = new Sensor[2];
            Temperature temperature = new Temperature("asd", "asd222", "wewe", 32, 21);
            sensors[0] = temperature;
            Console.WriteLine(sensors[0].Unit);
        }
    }
}
