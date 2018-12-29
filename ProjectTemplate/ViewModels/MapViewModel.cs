using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.ViewModels
{
    class MapViewModel : BaseViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public MapViewModel()
        {
            MapWithSensors.Focus();
            MapWithSensors.Mode = new AerialMode(true);

            AddPushpin(new Location(47.6035, -122.3294), "Seattle", "Seattle is in the state of Washington. ", DataLayer);

            AddPushpin(new Location(51.5063, -0.1271), "London", "London is the capital city of England and the United Kingdom, and the largest city in the United Kingdom.", DataLayer);

            //track current map position
            MapWithSensors.ViewChangeOnFrame += new EventHandler<MapEventArgs>(MapWithSensors_ViewChangeOnFrame);
            //add a pushpin with a mouse double click event
            //MapWithSensors.MouseDoubleClick += new MouseButtonEventHandler(MapWithSensors_MouseDoubleClick);
        }

        //void MapWithSensors_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    Pushpin temp = new Pushpin();
        //    Point point = e.GetPosition(this);
        //    double x = point.X;
        //    double y = point.Y;

        //    temp.Location = new Location(x,y);
        //    PushpinsLayer.AddChild(temp, temp.Location);
        //    //string name = "test";

        //    //add to dictionary
        //    //pushpins.Add(name, temp);

        //    //add to the layer and then to the children
        //    //MapLayer.SetPosition(temp, temp.Location);
        //    //MapWithSensors.Children.Add(temp);
        //}

        void MapWithSensors_ViewChangeOnFrame(object sender, MapEventArgs e)
        {
            //Gets the map that raised this event
            Map map = (Map)sender;
            //Gets the bounded rectangle for the current frame
            LocationRect bounds = map.BoundingRectangle;
            //Update the current latitude and longitude
            if (CurrentPosition != null && !string.IsNullOrWhiteSpace(CurrentPosition.Text))
            {
                CurrentPosition.Text = string.Format("Northwest: {0:F5}, Southeast: {1:F5}",
                        bounds.Northwest, bounds.Southeast);
            }
        }

        public void AddPushpin(Location latlong, string title, string description, MapLayer layer)
        {
            Pushpin temp = new Pushpin()
            {
                Tag = new Metadata()
                {
                    Title = title,
                    Description = description
                }
            };

            MapLayer.SetPosition(temp, latlong);

            temp.MouseLeftButtonDown += PinClicked;

            layer.Children.Add(temp);

        }

        private void PinClicked(object sender, MouseButtonEventArgs e)
        {
            Pushpin temp = sender as Pushpin;
            Metadata metadata = (Metadata)temp.Tag;

            if (!String.IsNullOrEmpty(metadata.Title) || !String.IsNullOrEmpty(metadata.Description))
            {
                Infobox.DataContext = metadata;

                Infobox.Visibility = Visibility.Visible;

                MapLayer.SetPosition(Infobox, MapLayer.GetPosition(temp));
            }
            else
            {
                Infobox.Visibility = Visibility.Collapsed;
            }
        }

        private void CloseInfobox_Clicked(object sender, RoutedEventArgs e)
        {
            Infobox.Visibility = Visibility.Collapsed;
        }
    }
