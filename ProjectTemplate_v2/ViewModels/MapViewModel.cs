using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ProjectTemplate_v2.ViewModels
{
    public class PushpinModel
    {
        public Location Location { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public PushpinModel(Location location, string title, string description)
        {
            Location = location;
            Title = title;
            Description = description;
        }
    }
    public class MapLocation
    {
        public Location Location { get; set; }
        public string Name { get; set; }
    }


    public class MapViewModel : BaseViewModel
    {
        private ObservableCollection<Pushpin> locations;
        private ObservableCollection<PushpinModel> pushpins;
        public Map MapWithMarkers { get; set; }

        public MapViewModel(ref Sensors sensors)
        {
            this.sensors = sensors;

            ObservableCollection<Pushpin> Locations = new ObservableCollection<Pushpin>();
            ObservableCollection<PushpinModel> Pushpins = new ObservableCollection<PushpinModel>();

            InitMap();
            Map MapWithSensors = new Map();
            if (sensors.List.Count == 0)
                MapWithSensors.Center = new Location(42.698334, 23.319941);

            //SetAllPushpinLocations(ref sensors, Locations, Pushpins);

        }

        private void InitMap()
        {
            MapWithMarkers = new Map
            {
                Center = new Location(42, 25),
                ZoomLevel = 12,
                Margin = new Thickness(10, 10, 300, 10),
                Mode = new AerialMode(true),
                BorderThickness = new Thickness(15),
                BorderBrush = Brushes.Black,
                CredentialsProvider = new ApplicationIdCredentialsProvider("Arlj7m-YopkSpqjw8gdI2PHqnd8tulYdY91G_h8qZ42jmUOPjjqFRnO7iMpk9TuS")
            };

            foreach (var sensor in sensors.List)
            {
                Pushpin pin = new Pushpin
                {
                    Location = new Location(sensor.Latitude, sensor.Longitude),
                    Name = sensor.Name.ToString(),
                    ToolTip = sensor.Description
                };
                //Locations.Add(pin);

                MapWithMarkers.Children.Add(pin);
            }
        }

        public ObservableCollection<PushpinModel> Pushpins
        {
            get { return pushpins; }
            set
            {
                if (pushpins != value)
                    pushpins = value;
                RaisePropertyChanged("Pushpins");
            }
        }

        public ObservableCollection<Pushpin> Locations
        {
            get { return locations; }
            set
            {
                if (locations != value)
                    locations = value;
                RaisePropertyChanged("Locations");
            }
        }
    }
}
