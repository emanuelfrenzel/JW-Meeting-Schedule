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

using JWMeetingSchedule.View;

using System.Windows;
using System.Windows.Controls.Primitives;

namespace JWMeetingSchedule
{
    public partial class MainWindow : Window
    {
        private ScheduleView scheduleView = new ScheduleView();
        private PersonsView personsView = new PersonsView();
        private SettingsView settingsView = new SettingsView();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = scheduleView;
        }

        private void BtnSchedule_Click(object sender, RoutedEventArgs e)
        {
            BtnSchedule.IsChecked = true;
            uncheckButtons(sender);
            DataContext = scheduleView;
        }

        private void BtnPersons_Click(object sender, RoutedEventArgs e)
        {
            BtnPersons.IsChecked = true;
            uncheckButtons(sender);
            DataContext = personsView;
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            BtnSettings.IsChecked = true;
            uncheckButtons(sender);
            DataContext = settingsView;
        }

        private void uncheckButtons(object sender)
        {
            foreach (ToggleButton btn in MenuGrid.Children)
            {
                if (btn != sender)
                {
                    btn.IsChecked = false;
                }
            }
        }
    }
}
