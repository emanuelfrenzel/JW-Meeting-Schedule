using JWMeetingSchedule.Model;
using JWMeetingSchedule.View;

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace JWMeetingSchedule.ViewModel
{
    public class LoadSchedule : ICommand
    {
        private Schedule schedule;
        private List<WeekSchedule> WeekSchedules;
        public event EventHandler CanExecuteChanged;
        public ObservableCollection<WeekView> WeekViews { get; set; }

        public LoadSchedule()
        {
            WeekViews = new ObservableCollection<WeekView>();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "HTML files (*.html)|*.html";
            if (openFileDialog.ShowDialog() == true)
            {
                schedule = new Schedule(openFileDialog.FileName);
                WeekSchedules = schedule.FindWeeks();
                foreach (var week in WeekSchedules)
                {
                    WeekViews.Add(new WeekView());
                }
            }
        }
    }
}