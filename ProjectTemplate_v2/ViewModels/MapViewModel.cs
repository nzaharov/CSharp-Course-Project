using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    public class MapViewModel:BaseViewModel
    {
        private ObservableCollection<Pushpin> locations;
        private ObservableCollection<PushpinModel> pushpins;


        public MapViewModel(ref Sensors sensors)
        {
            this.sensors = sensors;

            ObservableCollection<Pushpin> Locations = new ObservableCollection<Pushpin>();
            ObservableCollection<PushpinModel> Pushpins = new ObservableCollection<PushpinModel>();

            Map MapWithSensors = new Map();
            if (sensors.List.Count == 0)
                MapWithSensors.Center = new Location(42.698334, 23.319941);

            SetAllPushpinLocations(ref sensors, Locations, Pushpins);
            
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


        private void SetAllPushpinLocations(ref Sensors sensors, ObservableCollection<Pushpin> Locations, ObservableCollection<PushpinModel> Pushpins)
        {
            foreach (var sensor in sensors.List)
            {
                Pushpin temp = new Pushpin
                {
                    Location = new Location(sensor.Longitude, sensor.Latitude)
                };
                Locations.Add(temp);

                PushpinModel tempp = new PushpinModel(temp.Location, sensor.Name, sensor.Description);
                Pushpins.Add(tempp);
            }
            //e.Handled = true;
            //Point mousePosition = e.GetPosition((UIElement)sender);
            //Location pinLocation = operatorMap.ViewportPointToLocation(mousePosition);
            //if (pin == null)
            //{
            //    pin = new Pushpin();
            //    operatorMap.Children.Add(pin);
            //}
            //pin.Location = pinLocation;
            //this.viewModel.Evt.Latitude = pinLocation.Latitude;
            //this.viewModel.Evt.Longitude = pinLocation.Longitude;
        }
    }
}
