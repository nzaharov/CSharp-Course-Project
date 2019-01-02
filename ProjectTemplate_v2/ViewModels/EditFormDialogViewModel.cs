using System.Collections.ObjectModel;

namespace ProjectTemplate_v2.ViewModels
{
    public class EditFormDialogViewModel:BaseViewModel
    {
        public ObservableCollection<string> Types { get; private set; } = 
            new ObservableCollection<string>() { "Temperature", "Humidity", "Electricity Consumption", "Noise", "Window/Door" };

    }
}
