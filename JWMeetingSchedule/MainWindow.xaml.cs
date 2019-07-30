using JWMeetingSchedule.ViewModel;
using System.Windows;

namespace JWMeetingSchedule
{
    public partial class MainWindow : Window
    {
        private Schedule schedule;
        private PeopleList peopleList;

        public MainWindow()
        {
            InitializeComponent();
            schedule = new Schedule();
            //TxtWeek.Text = schedule.CurrentWeek;
            peopleList = new PeopleList();
            DataContext = peopleList;
        }
    }
}
