//MIT License

//Copyright (c) 2019 Emanuel Frenzel

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

using JWMeetingSchedule.Model;
using JWMeetingSchedule.Model.Schedule;
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
        private MounthSchedule mounthSchedule;
        private List<WeekSchedule> weekSchedules;
        public event EventHandler CanExecuteChanged;
        public ObservableCollection<WeekView> WeekViews { get; } = new ObservableCollection<WeekView>();

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "HTML files (*.html)|*.html"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                mounthSchedule = new MounthSchedule(openFileDialog.FileName);
                weekSchedules = mounthSchedule.FindWeeks();
                WeekViews.Clear();
                foreach (var week in weekSchedules)
                {
                    WeekViews.Add(new WeekView(new WeekViewModel(week)));
                }
            }
        }
    }
}