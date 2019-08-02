using JWMeetingSchedule.View;

using System.Windows;

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
            BtnSchedule.IsChecked = true;
        }

        private void BtnSchedule_Checked(object sender, RoutedEventArgs e)
        {
            UncheckButtons(sender);
            DataContext = scheduleView;
        }

        private void BtnPersons_Checked(object sender, RoutedEventArgs e)
        {
            UncheckButtons(sender);
            DataContext = personsView;
        }

        private void BtnSettings_Checked(object sender, RoutedEventArgs e)
        {
            UncheckButtons(sender);
            DataContext = settingsView;
        }

        private void UncheckButtons(object sender)
        {
            if (BtnSchedule != sender)
            {
                BtnSchedule.IsChecked = false;
            }
            if (BtnPersons != sender)
            {
                BtnPersons.IsChecked = false;
            }
            if (BtnSettings != sender)
            {
                BtnSettings.IsChecked = false;
            }
        }
    }
}
