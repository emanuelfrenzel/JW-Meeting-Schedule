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
