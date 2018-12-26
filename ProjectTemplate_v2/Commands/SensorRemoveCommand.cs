using ProjectTemplate_v2.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace ProjectTemplate_v2.Commands
{
    public class SensorRemoveCommand : ICommand
    {
        private ListViewModel vm;

        public SensorRemoveCommand(ListViewModel listViewModel)
        {
            vm = listViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            vm.Remove();
        }
    }
}
