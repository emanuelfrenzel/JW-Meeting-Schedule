using JWMeetingSchedule.View;
using System.Collections.ObjectModel;

namespace JWMeetingSchedule.ViewModel
{
    public class ScheduleViewModel
    {
        public LoadSchedule LoadSchedule { get; }
        public ObservableCollection<WeekView> Weeks => LoadSchedule.WeekViews;

        public ScheduleViewModel()
        {
            LoadSchedule = new LoadSchedule();
        }
    }
}
