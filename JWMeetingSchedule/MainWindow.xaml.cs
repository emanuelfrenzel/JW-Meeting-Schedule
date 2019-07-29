using JWMeetingSchedule.ViewModel;

using System.Windows;

namespace JWMeetingSchedule
{
    public partial class MainWindow : Window
    {
        private Schedule schedule;

        public MainWindow()
        {
            InitializeComponent();
            schedule = new Schedule();
            TxtWeek.Text = schedule.CurrentWeek;
        }
    }
}
