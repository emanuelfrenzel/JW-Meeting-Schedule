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

        private void BtnSchedule_Click(object sender, RoutedEventArgs e)
        {
            BtnSchedule.IsChecked = true;
            BtnPersons.IsChecked = false;
        }

        private void BtnPersons_Click(object sender, RoutedEventArgs e)
        {
            BtnPersons.IsChecked = true;
            BtnSchedule.IsChecked = false;
        }
    }
}
