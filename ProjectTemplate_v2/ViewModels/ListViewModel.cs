using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace ProjectTemplate_v2.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        public ObservableCollection<Sensor> List { get; set; }
        public ICommand RemoveCommand { get; private set; }
        public ICommand FollowCommand { get; private set; }

        private Sensor selected;
        private string followButtonContent;

        public ListViewModel(ref Sensors sensors)
        {
            this.sensors = sensors;
            GetList(ref sensors);
            RemoveCommand = new DelegateCommand(RemoveSensor);
            FollowCommand = new DelegateCommand(ChangeFollow);
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
                        FollowButtonContent = !Selected.Followed ? "Follow" : "Unfollow";
                    RaisePropertyChanged("Selected");
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

        private void GetList(ref Sensors sensors)
        {
            List = sensors.List;
        }
    }
}
