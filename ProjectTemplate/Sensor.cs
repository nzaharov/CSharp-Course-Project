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

        private string name;
        private string description;
        private string url;
        private decimal latitude;
        private decimal longitude;
        private bool followed;


        protected Sensor(string name,string url,string description,decimal latitude,decimal longitude,bool follow)
        {
            Name = name;
            Url = url;
            Description = description;
            Latitude = latitude;
            Longitude = longitude;
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

        public decimal Longitude
        {
            get { return longitude; }
            set
            {
                if (longitude != value)
                {
                    longitude = value;
                    NotifyPropertyChanged("Longitude");
                }
            }
        }


        public decimal Latitude
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
