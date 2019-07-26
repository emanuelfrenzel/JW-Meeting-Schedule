using JWMeetingSchedule.Model;
using Utils.Collections.Generic;

using System.Collections.Generic;

namespace JWMeetingSchedule.ViewModel
{
    class ScheduleInfo
    {
        private List<string> weekNames;
        private int currentWeek;
        private ScheduleModel schedule;

        public string CurrentWeek
        {
            get
            {
                return weekNames[currentWeek];
            }
        }

        public ScheduleInfo()
        {
            weekNames = new List<string>();
            weekNames.AddLinesFromFile("weeknames.dat");
            currentWeek = 0;
            schedule = new ScheduleModel();
        }
    }
}
