using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace ProjectTemplate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Sensors sensors;

        public MainWindow()
        {
            InitializeComponent();
            InitializeList();
            MainPage mainPage = new MainPage(ref btnToMap,UpdateXml,ref sensors);
            Frame1.Navigate(mainPage);
        }

        private void InitializeList()
        {
            sensors = new Sensors();

            XmlSerializer serializer = new XmlSerializer(typeof(Sensors));

            FileStream fs;

            if (!File.Exists("sensors.xml"))
            {
                using (StreamWriter sw = new StreamWriter("sensors.xml"))
                {
                    serializer.Serialize(sw, sensors);
                }

            }

            fs = new FileStream("sensors.xml", FileMode.Open);
            sensors = (Sensors)serializer.Deserialize(fs);
            fs.Close();
        }

        private void UpdateXml(Sensors sensors)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(Sensors));
            TextWriter writer = new StreamWriter("sensors.xml");

            serializer.Serialize(writer, sensors);
            writer.Close();

        }

        private void BtnToMap_Click(object sender, RoutedEventArgs e)
        {
            //Frame frame = new Frame
            //{
            //    Source = new Uri("MapPage.xaml", UriKind.RelativeOrAbsolute)
            //};
            //stkPanel1.Children.Add(frame);

            btnToMap.Visibility = Visibility.Collapsed;
            btnToMain.Visibility = Visibility.Visible;
        }

        private void BtnToMain_Click(object sender, RoutedEventArgs e)
        {
            btnToMap.Visibility = Visibility.Visible;
            btnToMain.Visibility = Visibility.Collapsed;
        }

        private void Canvas1_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if(e.Delta<0 && btnToMap.Visibility == Visibility.Visible)
            {
                BtnToMap_Click(sender,e);
            }
            else if(e.Delta>0 && btnToMain.Visibility == Visibility.Visible)
            {
                BtnToMain_Click(sender, e);
            }
        }
    }
}
