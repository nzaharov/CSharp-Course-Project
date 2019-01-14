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
using System.Windows.Threading;

namespace ProjectTemplate_v2.Models.Gauges
{
    /// <summary>
    /// Interaction logic for HumidityGaugeCtrl.xaml
    /// </summary>
    public partial class HumidityGaugeCtrl : UserControl
    {
        private static Random rand;

        public HumidityGaugeCtrl(HumiditySensor sensor)
        {
            InitializeComponent();
            minMarker.Value=(double)sensor.MinValue;
            maxMarker.Value = (double)sensor.MaxValue;
            humidityGauge.ToolTip = sensor.Name;

            rand = new Random();
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(rand.Next(1, 3))
            };
            //MessageBox.Show($"{timer.Interval}");
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        void Timer_Tick(object sender,EventArgs e)
        {
            Needle.Value = rand.Next(0, 101);
        }
    }
}
