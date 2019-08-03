using System.Windows.Input;

namespace JWMeetingSchedule.ViewModel
{
    public class ScheduleViewModel
    {
        public ICommand LoadSchedule { get; }

        public ScheduleViewModel()
        {
            LoadSchedule = new LoadSchedule();
        }
    }
}
