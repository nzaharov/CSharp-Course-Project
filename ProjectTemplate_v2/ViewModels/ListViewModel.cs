using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.Linq;
using ProjectTemplate_v2.Views;
using System.Windows.Input;
using Telerik.Windows.Controls;
using System.Windows.Data;

namespace ProjectTemplate_v2.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        public ObservableCollection<Sensor> List { get; set; }
        public ICommand RemoveCommand { get; private set; }
        public ICommand FollowCommand { get; private set; }
        public ICommand EditCommand { get; private set; }

        private Sensor selected;
        private string followButtonContent;
        private PackIcon sensorIcon;

        public ListViewModel(ref Sensors sensors)
        {
            this.sensors = sensors;
            GetList(ref sensors);
            RemoveCommand = new DelegateCommand(RemoveSensor);
            FollowCommand = new DelegateCommand(ChangeFollow);
            EditCommand = new DelegateCommand(ExecuteEditDialog);
            SensorIcon = new PackIcon
            {
                Width = 25,
                Height=25,
                Opacity=.80
            };
        }

        private async void ExecuteEditDialog(object obj)
        {
            var view = new EditFormDialog
            {
                DataContext = new EditFormDialogViewModel(ref sensors, Selected)
            };
            await DialogHost.Show(view);
        }

        private void RemoveSensor(object param)
        {
            sensors.List
                .Where(item => Selected == item)
                .ToList().All(i => sensors.List.Remove(i));
            UpdateXml(sensors);
        }

        private void ChangeFollow(object param)
        {
            sensors.List
                .Where(item => Selected == item)
                .Select(item => item.Followed = !item.Followed).ToList();

            UpdateXml(sensors);
        }

        public Sensor Selected
        {
            get { return selected; }
            set
            {
                if (selected != value)
                {
                    selected = value;
                    if (Selected != null)
                    {

                        FollowButtonContent = !Selected.Followed ? "Follow" : "Unfollow";

                        if (selected is HumiditySensor)
                            SensorIcon.Kind = PackIconKind.Humidity;
                        else if (selected is NoiseSensor)
                            SensorIcon.Kind = PackIconKind.VolumeHigh;
                        else if (selected is PowerConsumptionSensor)
                            SensorIcon.Kind = PackIconKind.Electricity;
                        else if (selected is TemperatureSensor)
                            SensorIcon.Kind = PackIconKind.ThermometerLines;
                        else
                            SensorIcon.Kind = PackIconKind.DoorOpen;
                    }

                    RaisePropertyChanged("Selected");
                }
            }
        }


        public PackIcon SensorIcon
        {
            get { return sensorIcon; }
            set
            {
                if (sensorIcon != value)
                {
                    sensorIcon = value;
                    RaisePropertyChanged("SensorIcon");
                }
            }
        }

        public string FollowButtonContent
        {
            get { return followButtonContent; }
            set
            {
                if (followButtonContent != value)
                {
                    followButtonContent = value;
                    RaisePropertyChanged("FollowButtonContent");
                }
            }
        }

        private void GetList(ref Sensors sensors)
        {
            List = sensors.List;
        }
    }
}
