using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectTemplate
{
    [XmlInclude(typeof(TemperatureSensor))]
    [XmlInclude(typeof(HumiditySensor))]
    [XmlInclude(typeof(PowerConsumptionSensor))]
    [XmlInclude(typeof(NoiseSensor))]
    [XmlInclude(typeof(WindowDoorSensor))]
    public class Sensors
    {
        [XmlArray("Sensors")]
        public ObservableCollection<Sensor> List { get; set; }

        public Sensors()
        {
            List = new ObservableCollection<Sensor>();
        }
    }
}
