using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate
{
    public class WindowDoorSensor:Sensor
    {
        private string opened;

        public WindowDoorSensor(string name, string url, string description, double latitude, double longitude,bool followed,string opened) 
            : base(name, url, description, latitude, longitude,followed)
        {
            Opened = opened;
        }

        public WindowDoorSensor():base()
        {
            Opened = null;
        }

        public string Opened
        {
            get { return opened; }
            set
            {
                if (opened != value)
                {
                    opened = value;
                    NotifyPropertyChanged("Opened");
                }
            }
        }

    }
}
