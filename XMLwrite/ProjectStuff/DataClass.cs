using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectStuff
{
    public class DataClass:INotifyPropertyChanged
    {
        [XmlAttribute]
        private string name;
        private string data2;
        private string data3;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Data3
        {
            get { return data3; }
            set
            {
                if (data3 != value)
                {
                    data3 = value;
                    NotifyPropertyChanged("Data3");
                }
            }
        }

        public string Data2
        {
            get { return data2; }
            set
            {
                if (data2 != value)
                {
                    data2 = value;
                    NotifyPropertyChanged("Data3");
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
                    NotifyPropertyChanged("Data3");
                }
            }
        }


        public DataClass(string bir,string iki,string uc)
        {
            Name = bir;
            Data2 = iki;
            Data3 = uc;
        }

        public DataClass():this(null,null,null)
        {

        }

        public void NotifyPropertyChanged(string propName)
        { 
            PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propName));
        }

        public override string ToString()
        {
            return string.Format($"{Name}");
        }
    }
}
