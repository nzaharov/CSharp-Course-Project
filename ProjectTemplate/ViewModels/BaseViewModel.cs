using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectTemplate.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected Sensors sensors;

        protected virtual void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected void UpdateXml(Sensors sensors)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Sensors));
            TextWriter writer = new StreamWriter("Sensors.xml");

            serializer.Serialize(writer, sensors);
            writer.Close();
        }
    }
}
