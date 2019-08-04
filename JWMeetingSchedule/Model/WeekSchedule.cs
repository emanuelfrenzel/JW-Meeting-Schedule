using System;

namespace JWMeetingSchedule.Model
{
    class WeekSchedule
    {
        public DateTime StartDate { get; set; }

        public WeekSchedule(DateTime dateTime)
        {
            this.StartDate = dateTime;
        }
    }
}
