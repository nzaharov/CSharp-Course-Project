using System;
using System.Windows;
using System.Windows.Input;
using ProjectTemplate_v2.ViewModels;
using Telerik.Windows.Controls;

namespace ProjectTemplate_v2.Commands
{
    class TileGeneratingCommand : ICommand
    {
        private MainViewModel vm;

        public TileGeneratingCommand(MainViewModel main)
        {
            vm = main;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            vm.AutoGenerateTile((AutoGeneratingTileEventArgs)parameter);
        }
    }
}
