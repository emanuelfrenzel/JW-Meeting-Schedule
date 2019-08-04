using JWMeetingSchedule.ViewModel;
using System.Windows.Controls;

namespace JWMeetingSchedule.View
{
    public partial class ScheduleView : UserControl
    {
        public ScheduleView()
        {
            InitializeComponent();
            DataContext = new ScheduleViewModel();
        }
    }
}
