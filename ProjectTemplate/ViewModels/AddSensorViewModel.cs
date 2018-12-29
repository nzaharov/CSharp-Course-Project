using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ProjectTemplate.ViewModels
{
    public class AddSensorViewModel:BaseViewModel
    {
        private string selectedItem;
        private string unit;
        private bool opened;
        private bool tracking = true;
        private Visibility visibility1;
        private Visibility visibility2;
        //data members

        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }
        public ObservableCollection<string> Types { get; private set; }
        public ICommand SubmitCommand { get; private set; }

        public AddSensorViewModel(ref Sensors sensors)
        {
            Types = new ObservableCollection<string>() { "Temperature", "Humidity", "Electricity Consumption", "Noise", "Window/Door" };
            Visibility1 = Visibility.Visible;
            Visibility2 = Visibility.Collapsed;
            this.sensors = sensors;
            SubmitCommand = new SensorSubmitCommand(this);
        }

        public void Submit()
        {
            Sensor sensor;

            switch (SelectedItem)
            {
                case "Temperature":
                    sensor = new TemperatureSensor(Name, Url, Description, Latitude, Longtitude, Tracking, MinValue, MaxValue);
                    break;
                case "Humidity":
                    sensor = new HumiditySensor(Name, Url, Description, Latitude, Longtitude, Tracking, MinValue, MaxValue);
                    break;
                case "Electricity Consumption":
                    sensor = new PowerConsumptionSensor(Name, Url, Description, Latitude, Longtitude, Tracking, MinValue, MaxValue);
                    break;
                case "Noise":
                    sensor = new TemperatureSensor(Name, Url, Description, Latitude, Longtitude, Tracking, MinValue, MaxValue);
                    break;
                case "Window/Door":
                    sensor = new WindowDoorSensor(Name, Url, Description, Latitude, Longtitude, Tracking, Opened);
                    break;
                default:
                    sensor = null;
                    break;
            }

            sensors.List.Add(sensor);
            sensors.FollowedList.Refresh();
            UpdateXml(sensors);
        }

        public bool Opened
        {
            get
            {
                return opened;
            }
            set
            {
                if(opened != value)
                {
                    opened = value;
                    RaisePropertyChanged("Opened");
                }
            }
        }

        public bool Tracking
        {
            get
            {
                return tracking;
            }
            set
            {
                if(tracking != value)
                {
                    tracking = value;
                    RaisePropertyChanged("Tracking");
                }
            }
        }

        public Visibility Visibility1
        {
            get
            {
                return visibility1;
            }
            set
            {
                if(visibility1 != value)
                {
                    visibility1 = value;
                    RaisePropertyChanged("Visibility1");
                }
            }
        }

        public Visibility Visibility2
        {
            get
            {
                return visibility2;
            }
            set
            {
                if(visibility2 != value)
                {
                    visibility2 = value;
                    RaisePropertyChanged("Visibility2");
                }
            }
        }

        public string Unit
        {
            get
            {
                return unit;
            }
            set
            {
                if (unit != value)
                {
                    unit = value;
                    RaisePropertyChanged("Unit");
                }
            }
        }

        public string SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                if(selectedItem != value)
                {
                    switch (value)
                    {
                        case "Temperature":
                            this.Unit = "°C";
                            Visibility1 = Visibility.Visible;
                            Visibility2 = Visibility.Collapsed;
                            break;
                        case "Humidity":
                            this.Unit = "%";
                            Visibility1 = Visibility.Visible;
                            Visibility2 = Visibility.Collapsed;
                            break;
                        case "Electricity Consumption":
                            this.Unit = "W";
                            Visibility1 = Visibility.Visible;
                            Visibility2 = Visibility.Collapsed;
                            break;
                        case "Noise":
                            this.Unit = "dB";
                            Visibility1 = Visibility.Visible;
                            Visibility2 = Visibility.Collapsed;
                            break;
                        case "Window/Door":
                            this.Unit = "";
                            Visibility2 = Visibility.Visible;
                            Visibility1 = Visibility.Collapsed;
                            break;
                    }
                    selectedItem = value;
                    RaisePropertyChanged("SelectedItem");
                }
            }
        }
        
    }
}
