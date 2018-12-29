using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Gauge;

namespace ProjectTemplate.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        public ICommand AutoTileCommand { get; private set; }
        public ICollectionView FollowedList { get; private set; }

        public MainViewModel(ref Sensors sensors)
        {
            this.sensors = sensors;
            GetFollowedList(ref sensors);
        }

        private void GetFollowedList(ref Sensors sensors)
        {
            FollowedList = sensors.FollowedList;
        }

        public void AutoGenerateTile(AutoGeneratingTileEventArgs e)
        {
            Sensor sensor = e.Tile.Content as Sensor;

            if (sensor is HumiditySensor)
            {
                RadialScale scale = new RadialScale
                {
                    Min = 0,
                    Max = 100,
                    ToolTip = sensor.Name,
                    FontSize = 11
                };

                Needle needle = new Needle
                {
                    Value = 20
                };

                Marker min = new Marker
                {
                    Value = Convert.ToDouble(((HumiditySensor)sensor).MinValue)
                };

                Marker max = new Marker
                {
                    Value = Convert.ToDouble(((HumiditySensor)sensor).MaxValue)
                };

                scale.Indicators.Add(needle);
                scale.Indicators.Add(new Pinpoint());
                scale.Indicators.Add(min);
                scale.Indicators.Add(max);
                RadRadialGauge rad = new RadRadialGauge();
                rad.Items.Add(scale);
                StyleManager.SetTheme(rad, new MaterialTheme());
                e.Tile.Content = rad;
                e.Tile.Background = new SolidColorBrush(Colors.Teal);
                e.Tile.TileType = TileType.Single;
            }
        }
    }
}
