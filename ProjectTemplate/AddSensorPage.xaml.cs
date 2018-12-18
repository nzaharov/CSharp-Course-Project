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

namespace ProjectTemplate
{
    /// <summary>
    /// Interaction logic for AddSensorPage.xaml
    /// </summary>
    public partial class AddSensorPage : Page
    {
        private Button toMap;
        private Action<Sensors> updateXml;
        private Sensors sensors;

        public AddSensorPage()
        {
            InitializeComponent();
        }

        public AddSensorPage(ref Button button, Action<Sensors> action, ref Sensors sensors) : this()
        {
            toMap = button;
            updateXml = action;
            this.sensors = sensors;
            toMap.Visibility = Visibility.Collapsed;
        }

        private void BtnToMain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            toMap.Visibility = Visibility.Visible;
        }

        private void CmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbType.SelectedIndex)
            {
                case 0:
                    lblMetrics1.Content = "°C";
                    lblMetrics2.Content = "°C";
                    Show();
                    break;
                case 1:
                    lblMetrics1.Content = "% ";
                    lblMetrics2.Content = "% ";
                    Show();
                    break;
                case 2:
                    lblMetrics1.Content = "W ";
                    lblMetrics2.Content = "W ";
                    Show();
                    break;
                case 3:
                    lblMetrics1.Content = "dB";
                    lblMetrics2.Content = "dB";
                    Show();
                    break;
                case 4:
                    if (cmbDoorWindow.Visibility != Visibility.Collapsed) return;
                    wrpNotDoorWindow.Visibility = Visibility.Collapsed;
                    cmbDoorWindow.Visibility = Visibility.Visible;
                    break;

            }

            void Show()
            {
                if (cmbDoorWindow.Visibility == Visibility.Collapsed) return;
                cmbDoorWindow.Visibility = Visibility.Collapsed;
                wrpNotDoorWindow.Visibility = Visibility.Visible;
            }
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Sensor sensor;
            bool isFollowed = ckbFollow.IsChecked == true;

            switch (cmbType.SelectedIndex)
            {
                case 0:
                    sensor = new TemperatureSensor(
                        txtName.Text,
                        txtUrl.Text,
                        new TextRange(txtDescription.Document.ContentStart, txtDescription.Document.ContentEnd).Text,
                        Convert.ToDecimal(txtLatitude.Text),
                        Convert.ToDecimal(txtLongitude.Text),
                        isFollowed,
                        Convert.ToDecimal(txtMinValue.Text),
                        Convert.ToDecimal(txtMaxValue.Text));
                    break;
                case 1:
                    sensor = new HumiditySensor(
                        txtName.Text,
                        txtUrl.Text,
                        new TextRange(txtDescription.Document.ContentStart, txtDescription.Document.ContentEnd).Text,
                        Convert.ToDecimal(txtLatitude.Text),
                        Convert.ToDecimal(txtLongitude.Text),
                        isFollowed,
                        Convert.ToDecimal(txtMinValue.Text),
                        Convert.ToDecimal(txtMaxValue.Text));
                    break;
                case 2:
                    sensor = new PowerConsumptionSensor(
                        txtName.Text,
                        txtUrl.Text,
                        new TextRange(txtDescription.Document.ContentStart, txtDescription.Document.ContentEnd).Text,
                        Convert.ToDecimal(txtLatitude.Text),
                        Convert.ToDecimal(txtLongitude.Text),
                        isFollowed,
                        Convert.ToDecimal(txtMinValue.Text),
                        Convert.ToDecimal(txtMaxValue.Text));
                    break;
                case 3:
                    sensor = new TemperatureSensor(
                        txtName.Text,
                        txtUrl.Text,
                        new TextRange(txtDescription.Document.ContentStart, txtDescription.Document.ContentEnd).Text,
                        Convert.ToDecimal(txtLatitude.Text),
                        Convert.ToDecimal(txtLongitude.Text),
                        isFollowed,
                        Convert.ToDecimal(txtMinValue.Text),
                        Convert.ToDecimal(txtMaxValue.Text));
                    break;
                case 4:
                    string opened = cmbDoorWindow.SelectedIndex == 0 ? "true" : "false";
                    sensor = new WindowDoorSensor(
                        txtName.Text,
                        txtUrl.Text,
                        new TextRange(txtDescription.Document.ContentStart, txtDescription.Document.ContentEnd).Text,
                        Convert.ToDecimal(txtLatitude.Text),
                        Convert.ToDecimal(txtLongitude.Text),
                        isFollowed,
                        opened);
                    break;
                default:
                    sensor = null;
                    break;
            }

            sensors.List.Add(sensor);
            updateXml(sensors);
        }
    }
}
