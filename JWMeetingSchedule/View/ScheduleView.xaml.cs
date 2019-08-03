using JWMeetingSchedule.ViewModel;
using System.Windows.Controls;

namespace JWMeetingSchedule.View
{
    /// <summary>
    /// Interaction logic for ScheduleView.xaml
    /// </summary>
    public partial class ScheduleView : UserControl
    {
        private ScheduleViewModel scheduleViewModel;

        public ScheduleView()
        {
            InitializeComponent();
            scheduleViewModel = new ScheduleViewModel();
            DataContext = scheduleViewModel;
        }   
    }
}
