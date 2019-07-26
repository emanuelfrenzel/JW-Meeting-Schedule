using JWMeetingSchedule.ViewModel;

using System.Windows;

namespace JWMeetingSchedule
{
    public partial class MainWindow : Window
    {
        private ScheduleInfo schedule;

        public MainWindow()
        {
            InitializeComponent();
            schedule = new ScheduleInfo();
            TxtWeek.Text = schedule.CurrentWeek;
        }
    }
}
