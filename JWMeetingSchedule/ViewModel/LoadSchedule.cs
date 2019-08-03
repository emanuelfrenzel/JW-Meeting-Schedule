using Microsoft.Win32;
using System;
using System.Windows.Input;

namespace JWMeetingSchedule.ViewModel
{
    internal class LoadSchedule : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "HTML files (*.html)|*.html";
            openFileDialog.ShowDialog();

        }
    }
}