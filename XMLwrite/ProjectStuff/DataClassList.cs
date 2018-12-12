using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectStuff
{
    public class DataClassList
    {
        [XmlArray("Sensors")]
        public ObservableCollection<DataClass> List { get; set; }

        public DataClassList()
        {
            List = new ObservableCollection<DataClass>();
        }
    }
}
