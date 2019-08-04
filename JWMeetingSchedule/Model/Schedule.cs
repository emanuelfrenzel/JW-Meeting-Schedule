using System;
using System.Collections.Generic;
using System.Globalization;
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

        internal List<WeekSchedule> FindWeeks()
        {
            var weeks = new List<WeekSchedule>();
            foreach (Match match in Regex.Matches(fileContent, "Săptămâna care începe la "))
            {
                var stringStart = match.Index + match.Length;
                var startDate = fileContent.Substring(stringStart, 10);
                var week = new WeekSchedule(DateTime.Parse(startDate,
                          new CultureInfo("ro-Ro")));
                weeks.Add(week);
            }
            return weeks;
        }
    }
}
