using System.IO;
using System.Windows;
using System.Xml.Serialization;
using ProjectTemplate.ViewModels;

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
            DataContext = new MainViewModel(ref sensors);
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

        private void BtnToSensorAdd_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AddSensorViewModel(ref sensors);
        }

        private void BtnToSensorList_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ListViewModel(ref sensors);
        }

        private void BtnToMain_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MainViewModel(ref sensors);
        }
    }
}
