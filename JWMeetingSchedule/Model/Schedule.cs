using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace JWMeetingSchedule.Model
{
    public class Schedule
    {
        private string fileContent;

        public Schedule(string fileName)
        {
            fileContent = File.ReadAllText(fileName);
        }

        public List<WeekSchedule> FindWeeks()
        {
            var weeks = new List<WeekSchedule>();
            foreach (Match match in Regex.Matches(fileContent, "Săptămâna care începe la "))
            {
                var stringStart = match.Index + match.Length;
                var dataString = fileContent.Substring(stringStart);
                var week = new WeekSchedule(dataString);
                weeks.Add(week);
            }
            return weeks;
        }
    }
}
