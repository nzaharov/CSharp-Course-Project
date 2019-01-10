using ProjectTemplate_v2.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Gauge;

namespace ProjectTemplate_v2.ViewModels
{
    public class DashViewModel : BaseViewModel
    {
        //public ICommand AutoTileCommand { get; private set; }
        public ObservableCollection<Sensor> FollowedList { get; set; }

        public DashViewModel(Sensors sensors)
        {
            this.sensors = sensors;
            GetFollowedList(sensors);
            HttpService.InitializeClient();
            //AutoTileCommand = new DelegateCommand(AutoGenerateTile);
        }

        private void GetFollowedList(Sensors sensors)
        {
            FollowedList = new ObservableCollection<Sensor>(sensors.List);
            ICollectionView source = CollectionViewSource.GetDefaultView(FollowedList);
            source.Filter = item => ((Sensor)item).Followed;
        }

        public static void AutoGenerateTile(object e)
        {
            Sensor sensor = ((AutoGeneratingTileEventArgs)e).Tile.Content as Sensor;

            ((AutoGeneratingTileEventArgs)e).Tile.Background = new SolidColorBrush(Colors.Teal);
            ((AutoGeneratingTileEventArgs)e).Tile.TileType = TileType.Single;

            string url = $"{sensor.Url}/{sensor.Name}";

            if (sensor is HumiditySensor)
            {
                double val = 0; // HttpService.GetProductValueAsync(url).Result;

                RadialScale scale = new RadialScale
                {
                    Min = 0,
                    Max = 100,
                    ToolTip = sensor.Name,
                    FontSize = 11
                };

                Needle needle = new Needle
                {
                    Value = val
                };
                scale.Indicators.Add(needle);


                Marker min = new Marker
                {
                    Value = Convert.ToDouble(((HumiditySensor)sensor).MinValue)
                };

                Marker max = new Marker
                {
                    Value = Convert.ToDouble(((HumiditySensor)sensor).MaxValue)
                };


                scale.Indicators.Add(new Pinpoint());
                scale.Indicators.Add(min);
                scale.Indicators.Add(max);
                RadRadialGauge rad = new RadRadialGauge();
                rad.Items.Add(scale);
                StyleManager.SetTheme(rad, new MaterialTheme());
                ((AutoGeneratingTileEventArgs)e).Tile.Content = rad;

            }
        }
    }
}
