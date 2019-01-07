﻿using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.Linq;
using ProjectTemplate_v2.Views;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace ProjectTemplate_v2.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        public ObservableCollection<Sensor> List { get; set; }
        public ICommand RemoveCommand { get; private set; }
        public ICommand FollowCommand { get; private set; }
        public ICommand EditCommand { get; private set; }

        private Sensor selected;
        private string followButtonContent;
        private PackIconKind iconKind;


        public ListViewModel(Sensors sensors)
        {
            this.sensors = sensors;
            //GetList(ref sensors);
            List = sensors.List;
            RemoveCommand = new DelegateCommand(RemoveSensor);
            FollowCommand = new DelegateCommand(ChangeFollow);
            EditCommand = new DelegateCommand(ExecuteEditDialog);
        }

        private async void ExecuteEditDialog(object obj)
        {
            var view = new EditFormDialog
            {
                DataContext = new EditFormDialogViewModel(sensors, Selected)
            };
            await DialogHost.Show(view);
        }

        private void RemoveSensor(object param)
        {
            sensors.List
                .Where(item => Selected == item)
                .ToList().All(i => sensors.List.Remove(i));
            UpdateXml(sensors);
        }

        private void ChangeFollow(object param)
        {
            sensors.List
                .Where(item => Selected == item)
                .Select(item => item.Followed = !item.Followed).ToList();

            UpdateXml(sensors);
        }

        public Sensor Selected
        {
            get { return selected; }
            set
            {
                if (selected != value)
                {
                    selected = value;
                    if (Selected != null)
                    {
                        FollowButtonContent = !Selected.Followed ? "Follow" : "Unfollow";

                        if (selected is HumiditySensor)
                            IconKind = PackIconKind.Humidity;
                        else if (selected is NoiseSensor)
                            IconKind = PackIconKind.VolumeHigh;
                        else if (selected is PowerConsumptionSensor)
                            IconKind = PackIconKind.Electricity;
                        else if (selected is TemperatureSensor)
                            IconKind = PackIconKind.ThermometerLines;
                        else
                            IconKind = PackIconKind.DoorOpen;
                    }

                    RaisePropertyChanged("Selected");
                }
            }
        }


        public PackIconKind IconKind
        {
            get { return iconKind; }
            set
            {
                if (iconKind != value)
                {
                    iconKind = value;
                    RaisePropertyChanged("IconKind");
                }
            }
        }

        public string FollowButtonContent
        {
            get { return followButtonContent; }
            set
            {
                if (followButtonContent != value)
                {
                    followButtonContent = value;
                    RaisePropertyChanged("FollowButtonContent");
                }
            }
        }

        //private void GetList(ref Sensors sensors)
        //{
        //    List = sensors.List;
        //}
    }
}
