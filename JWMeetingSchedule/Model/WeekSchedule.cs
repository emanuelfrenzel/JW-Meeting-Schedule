using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace JWMeetingSchedule.Model
{
    public class WeekSchedule
    {
        public DateTime WeekStartDate { get; set; }
        public DateTime WeekMeetingDateTime { get; set; }
        public DateTime WeekendMeetingDateTime { get; set; }
        public bool Convention { get; set; }
        public bool Memorial { get; set; }
        public bool Supervisor { get; set; }
        public string President { get; set; }
        public string TreasuresTitle { get; set; }
        public string Treasures { get; set; }
        public string Gems { get; set; }
        public string Reading { get; set; }
        public string Assignment1Type { get; set; }
        public string Assignment1 { get; set; }
        public string Assignment2Type { get; set; }
        public string Assignment2 { get; set; }
        public string Assignment3Type { get; set; }
        public string Assignment3 { get; set; }
        public string Assignment4Type { get; set; }
        public string Assignment4 { get; set; }
        public bool ChristianLifeAssignment1OnlyVideo { get; set; }
        public bool ChristianLifeAssignment1Needs { get; set; }
        public string ChristianLifeAssignment1Title { get; set; }
        public string ChristianLifeAssignment1 { get; set; }
        public bool ChristianLifeAssignment2OnlyVideo { get; set; }
        public bool ChristianLifeAssignment2Needs { get; set; }
        public string ChristianLifeAssignment2Title { get; set; }
        public string ChristianLifeAssignment2 { get; set; }
        public string BibleStudy { get; set; }
        public string BibleStudyReader { get; set; }
        public string SupervisorWeekSpeechTitle { get; set; }
        public string WeekPrayer { get; set; }
        public string WeekendPresident { get; set; }
        public string PublicSpeechTitle { get; set; }
        public string PublicSpeech { get; set; }
        public string Watchtower { get; set; }
        public string WatchtowerReader { get; set; }
        public string FinalSpeechTitle { get; set; }
        public string FinalSpeech { get; set; }
        public string WeekendPrayer { get; set; }
        public string AV { get; set; }
        public string Microphone1 { get; set; }
        public string Microphone2 { get; set; }
        public string Order1 { get; set; }
        public string Order2 { get; set; }
        public int CleaningGroup { get; set; }

        public WeekSchedule(string dataString)
        {
            removeOtherWeeks(ref dataString);
            WeekStartDate = DateTime.Parse(dataString.Remove(10), new CultureInfo("ro-Ro"));
            President = findPrayer(ref dataString, "Rugăciune ", 30);
            if (President != null)
            {
                TreasuresTitle = find(ref dataString, "colspan=\"3\"", 38);
                Treasures = find(ref dataString, "name", 6);
            }
        }

        private string findPrayer(ref string dataString, string search, int returnIndex)
        {
            var match = Regex.Match(dataString, search);
            if (match != Match.Empty)
            {
                dataString = dataString.Substring(match.Index + returnIndex);
                match = Regex.Match(dataString, "[)]");
                return dataString.Remove(match.Index);
            }
            else
            {
                return null;
            }
        }

        private string find(ref string dataString, string search, int returnIndex)
        {
            var match = Regex.Match(dataString, search);
            if (match != Match.Empty)
            {
                dataString = dataString.Substring(match.Index + returnIndex);
                match = Regex.Match(dataString, "<");
                return dataString.Remove(match.Index);
            }
            else
            {
                return null;
            }
        }

        private void removeOtherWeeks(ref string dataString)
        {
            var match = Regex.Match(dataString, "END OF");
            dataString = dataString.Remove(match.Index);
        }
    }
}
