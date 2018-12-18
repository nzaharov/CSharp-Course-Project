using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.DataVisualization;
using Telerik.Windows.Controls.Gauge;

namespace ProjectTemplate
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private Button mapButton;
        private Action<Sensors> updateXml;
        private Sensors sensors;

        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(ref Button button, Action<Sensors> action, ref Sensors sensors) : this()
        {
            mapButton = button;
            updateXml = action;
            this.sensors = sensors;
            radTileList.ItemsSource = sensors.List.
                Where(item=>item.Followed);
        }

        private void BtnToSensorAdd_Click(object sender, RoutedEventArgs e)
        {
            AddSensorPage addSensorPage = new AddSensorPage(ref mapButton, updateXml, ref sensors);
            NavigationService.Navigate(addSensorPage);
        }

        private void RadTileList_AutoGeneratingTile(object sender, AutoGeneratingTileEventArgs e)
        {
            Sensor sensor = e.Tile.Content as Sensor;

            if (sensor is HumiditySensor)
            {
                RadialScale scale = new RadialScale
                {
                    Min = 0,
                    Max = 100,
                    ToolTip = "Humidity"
                };

                Needle needle = new Needle
                {
                    Value = 20
                };
                scale.Indicators.Add(needle);
                RadRadialGauge rad = new RadRadialGauge();
                rad.Items.Add(scale);
                e.Tile.Content = rad;
                e.Tile.Background = new SolidColorBrush(Colors.Teal);
                e.Tile.TileType = TileType.Single;
            }


        }
    }
}
