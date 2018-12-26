using ProjectTemplate_v2.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ProjectTemplate_v2.ViewModels
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
                if (selected != value)
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
