using JWMeetingSchedule.Model;
using Utils.Collections.Generic;

using System.Collections.Generic;

namespace JWMeetingSchedule.ViewModel
{
    class Schedule
    {
        private List<string> weekNames;
        private int currentWeek;
        public List<WeekSchedule> WeekSchedules;
        public PeopleList PeopleList;

        public string CurrentWeek
        {
            get
            {
                return weekNames[currentWeek];
            }
        }

        public Schedule()
        {
            weekNames = new List<string>();
            weekNames.AddLinesFromFile("weeknames.dat");
            currentWeek = 0;
            WeekSchedules = new List<WeekSchedule>();
            PeopleList = new PeopleList();
        }
    }
}
