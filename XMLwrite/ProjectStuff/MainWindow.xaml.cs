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
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace ProjectStuff
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public static DataClassList dataClassList;

        public MainWindow()
        {
            InitializeComponent();
            InitializeList();
        }

        private void InitializeList()
        {
            dataClassList = new DataClassList();

            XmlSerializer serializer = new XmlSerializer(typeof(DataClassList));

            FileStream fs;

            if (!File.Exists("test.xml"))
            {
                using (StreamWriter sw = new StreamWriter("test.xml"))
                {
                    serializer.Serialize(sw, dataClassList);
                }

            }

            fs = new FileStream("test.xml", FileMode.Open);
            dataClassList = (DataClassList)serializer.Deserialize(fs);
            fs.Close();
            //lbListBox.ItemsSource = dataClassList.List;

            Binding binding = new Binding
            {
                Source = dataClassList,
                Path = new PropertyPath("List")
            };

            lbListBox.SetBinding(ListBox.ItemsSourceProperty, binding);
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (txtData1.Text != "" && txtData2.Text != "" && txtData3.Text != "")
            {
                DataClass dataClass = new DataClass(txtData1.Text, txtData2.Text, txtData3.Text);
                dataClassList.List.Add(dataClass);
                UpdateXml();
            }
            else
            {
                MessageBox.Show("Fields empty", "Alert");
            }

        }

        private static void UpdateXml()
        {

            XmlSerializer serializer = new XmlSerializer(typeof(DataClassList));
            TextWriter writer = new StreamWriter("test.xml");

            serializer.Serialize(writer, dataClassList);
            writer.Close();

        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            dataClassList.List
                .Where(item => lbListBox.SelectedItem == item)
                .ToList().All(i => dataClassList.List.Remove(i));
            UpdateXml();
        }


        private void LbListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int index = dataClassList.List
                .IndexOf(dataClassList.List.Where(item => lbListBox.SelectedItem == item).First());
            //.Where(item => lbListBox.SelectedItem == item).First();

            listContent.Visibility = Visibility.Collapsed;
            detailsContent.Visibility = Visibility.Visible;

            //MessageBox.Show($"{selected.Name}\n{selected.Data2}\n{selected.Data3}\n", "Info");

            Binding binding = new Binding
            {
                Source = dataClassList.List[index],
                Path = new PropertyPath("Name"),
            };
            txtInfoName.SetBinding(TextBox.TextProperty, binding);

            Binding binding1 = new Binding
            {
                Source = dataClassList.List[index],
                Path = new PropertyPath("Data2")
            };
            txtInfoData2.SetBinding(TextBox.TextProperty, binding1);

            Binding binding2 = new Binding
            {
                Source = dataClassList.List[index],
                Path = new PropertyPath("Data3")
            };
            txtInfoData3.SetBinding(TextBox.TextProperty, binding2);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            EditDisabled();

            listContent.Visibility = Visibility.Visible;
            detailsContent.Visibility = Visibility.Collapsed;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            txtInfoName.IsEnabled = true;
            txtInfoName.BorderThickness = new Thickness(1);

            txtInfoData2.IsEnabled = true;
            txtInfoData2.BorderThickness = new Thickness(1);

            txtInfoData3.IsEnabled = true;
            txtInfoData3.BorderThickness = new Thickness(1);

            editVisible.Visibility = Visibility.Collapsed;
            saveVisible.Visibility = Visibility.Visible;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            int index = dataClassList.List
                        .IndexOf(dataClassList.List.Where(item => lbListBox.SelectedItem == item).First());

            DataClass dataClass = new DataClass(txtInfoName.Text, txtInfoData2.Text, txtInfoData3.Text);
            dataClassList.List[index] = dataClass;
            UpdateXml();

            EditDisabled();
        }

        private void EditDisabled()
        {
            txtInfoName.IsEnabled = false;
            txtInfoName.BorderThickness = new Thickness(0);

            txtInfoData2.IsEnabled = false;
            txtInfoData2.BorderThickness = new Thickness(0);

            txtInfoData3.IsEnabled = false;
            txtInfoData3.BorderThickness = new Thickness(0);

            editVisible.Visibility = Visibility.Visible;
            saveVisible.Visibility = Visibility.Collapsed;
        }
    }
}
