using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate
{
    public class Sensor:INotifyPropertyChanged
    {
        private const int POLLINGINTERVAL = 60;

        private string name;
        private string description;
        private string url;
        private double latitude;
        private double longtitude;
        private bool followed;


        protected Sensor(string name,string url,string description,double latitude, double longtitude,bool follow)
        {
            Name = name;
            Url = url;
            Description = description;
            Latitude = latitude;
            Longtitude = longtitude;
            Followed = follow;
        }

        public Sensor() : this(null,null,null,0,0,false)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propName));
        }

        public bool Followed
        {
            get { return followed; }
            set
            {
                if (followed != value)
                {
                    followed = value;
                    NotifyPropertyChanged("Followed");
                }
            }
        }

        public double Longtitude
        {
            get { return longtitude; }
            set
            {
                if (longtitude != value)
                {
                    longtitude = value;
                    NotifyPropertyChanged("Longtitude");
                }
            }
        }


        public double Latitude
        {
            get { return latitude; }
            set
            {
                if (latitude != value)
                {
                    latitude = value;
                    NotifyPropertyChanged("Latitude");
                }
            }
        }


        public string Url
        {
            get { return url; }
            set
            {
                if (url!= value)
                {
                    url = value;
                    NotifyPropertyChanged("Url");
                }
            }
        }


        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }


        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }


    }
}
