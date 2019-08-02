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
            BtnPersons.IsChecked = false;
            BtnSettings.IsChecked = false;
            DataContext = scheduleView;
        }

        private void BtnPersons_Checked(object sender, RoutedEventArgs e)
        {
            BtnSchedule.IsChecked = false;
            BtnSettings.IsChecked = false;
            DataContext = personsView;
        }

        private void BtnSettings_Checked(object sender, RoutedEventArgs e)
        {
            BtnSchedule.IsChecked = false;
            BtnPersons.IsChecked = false;
            DataContext = settingsView;
        }
    }
}
