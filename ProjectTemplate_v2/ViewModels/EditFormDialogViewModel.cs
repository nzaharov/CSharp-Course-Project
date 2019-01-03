using System.Collections.Generic;

namespace ProjectTemplate_v2.ViewModels
{
    public class EditFormDialogViewModel:BaseViewModel
    {
        //public List<string> Types { get; private set; } = 
        //    new List<string>() { "Temperature", "Humidity", "Electricity Consumption", "Noise", "Window/Door" };
        public Sensor Sensor { get; set; }

        public EditFormDialogViewModel(ref Sensors sensors,Sensor selected)
        {
            this.sensors = sensors;
            Sensor = selected;
        }
    }
}
