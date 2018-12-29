using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProjectTemplate.ViewModels
{
    public class ListViewModel:BaseViewModel
    {
        public ObservableCollection<Sensor> List { get; set; }
        public ICommand RemoveCommand { get; set; }
        private Sensor selected;

        public Sensor Selected
        {
            get { return selected; }
            set
            {
                if(selected != value)
                {
                    selected = value;
                    RaisePropertyChanged("Selected");
                }
            }
        }

        public ListViewModel(ref Sensors sensors)
        {
            this.sensors = sensors;
            GetList(ref sensors);
            RemoveCommand = new SensorRemoveCommand(this);
        }

        public void Remove()
        {
            MessageBox.Show(Selected.Name);
        }

        private void GetList(ref Sensors sensors)
        {
            List = sensors.List;
        }
    }
}
