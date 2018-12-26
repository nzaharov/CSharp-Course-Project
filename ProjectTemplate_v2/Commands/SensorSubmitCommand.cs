using ProjectTemplate_v2.ViewModels;
using System;
using System.Windows.Input;

namespace ProjectTemplate_v2.Commands
{
    class SensorSubmitCommand:ICommand
    {
        private AddSensorViewModel vm;

        public SensorSubmitCommand(AddSensorViewModel addSensorViewModel)
        {
            vm = addSensorViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            vm.Submit();
        }
    }
}
