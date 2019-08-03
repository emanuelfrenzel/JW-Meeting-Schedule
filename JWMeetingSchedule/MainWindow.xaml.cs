using JWMeetingSchedule.View;

using System.Windows;
using System.Windows.Controls.Primitives;

namespace JWMeetingSchedule
{
    public partial class MainWindow : Window
    {
        private ScheduleView scheduleView;
        private PersonsView personsView;
        private SettingsView settingsView;

        public MainWindow()
        {
            InitializeComponent();
            scheduleView = new ScheduleView();
            personsView = new PersonsView();
            settingsView = new SettingsView();
            DataContext = scheduleView;
        }

        private void BtnSchedule_Click(object sender, RoutedEventArgs e)
        {
            BtnSchedule.IsChecked = true;
            UncheckButtons(sender);
            DataContext = scheduleView;
        }

        private void BtnPersons_Click(object sender, RoutedEventArgs e)
        {
            BtnPersons.IsChecked = true;
            UncheckButtons(sender);
            DataContext = personsView;
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            BtnSettings.IsChecked = true;
            UncheckButtons(sender);
            DataContext = settingsView;
        }

        private void UncheckButtons(object sender)
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
