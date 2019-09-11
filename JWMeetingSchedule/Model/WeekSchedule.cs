using JWMeetingSchedule.Utils;

using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace JWMeetingSchedule.Model
{
    public class WeekSchedule
    {
        private string dataString;
        private string assignment1Type;
        private string assignment1;
        private string assignment1Assist;
        private string assignment2Type;
        private string assignment2;
        private string assignment2Assist;
        private string assignment3Type;
        private string assignment3;
        private string assignment3Assist;
        private string assignment4Type;
        private string assignment4;
        private string assignment4Assist;
        private bool christianLifeAssignment1OnlyVideo;
        private bool christianLifeAssignment1Needs;
        private string christianLifeAssignment1Title;
        private string christianLifeAssignment1;
        private bool christianLifeAssignment2OnlyVideo;
        private bool christianLifeAssignment2Needs;
        private string christianLifeAssignment2Title;
        private string christianLifeAssignment2;
        public DateTime WeekStartDate { get; set; }
        public DateTime WeekMeetingDateTime { get; set; }
        public DateTime WeekendMeetingDateTime { get; set; }
        public bool Convention { get; set; }
        public bool Memorial { get; set; }
        public string ExtraInfo { get; set; }
        public bool Supervisor { get; set; }
        public string President { get; set; }
        public string TreasuresTitle { get; set; }
        public string Treasures { get; set; }
        public string Gems { get; set; }
        public string Reading { get; set; }
        public string Assignment1Type => assignment1Type;
        public string Assignment1 => assignment1;
        public string Assignment1Assist => assignment1Assist;
        public string Assignment2Type => assignment2Type;
        public string Assignment2 => assignment2;
        public string Assignment2Assist => assignment2Assist;
        public string Assignment3Type => assignment3Type;
        public string Assignment3 => assignment3;
        public string Assignment3Assist => assignment3Assist;
        public string Assignment4Type => assignment4Type;
        public string Assignment4 => assignment4;
        public string Assignment4Assist => assignment4Assist;
        public bool ChristianLifeAssignment1OnlyVideo => christianLifeAssignment1OnlyVideo;
        public bool ChristianLifeAssignment1Needs => christianLifeAssignment1Needs;
        public string ChristianLifeAssignment1Title => christianLifeAssignment1Title;
        public string ChristianLifeAssignment1 => christianLifeAssignment1;
        public bool ChristianLifeAssignment2OnlyVideo => christianLifeAssignment2OnlyVideo;
        public bool ChristianLifeAssignment2Needs => christianLifeAssignment2OnlyVideo;
        public string ChristianLifeAssignment2Title => christianLifeAssignment2Title;
        public string ChristianLifeAssignment2 => christianLifeAssignment2;
        public string BibleStudy { get; set; }
        public string BibleStudyReader { get; set; }
        public string SupervisorName { get; set; }
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
            this.dataString = dataString.Remove("END OF");
            WeekStartDate = DateTime.Parse(dataString.Remove(10), new CultureInfo("ro-Ro"));
            President = findPrayer("Rugăciune ", 30);
            if (President != null)
            {
                TreasuresTitle = find("colspan=\"3\"", 38);
                Treasures = findName();
                Gems = findName();
                Reading = findName();
                findPreachingAssignment(ref assignment1Type, ref assignment1, ref assignment1Assist, "FM Talk 1");
                findPreachingAssignment(ref assignment2Type, ref assignment2, ref assignment2Assist, "FM Talk 2");
                findPreachingAssignment(ref assignment3Type, ref assignment3, ref assignment3Assist, "FM Talk 3");
                findPreachingAssignment(ref assignment4Type, ref assignment4, ref assignment4Assist, "FM Talk 4");
                findChristianLifeAssignment(ref christianLifeAssignment1OnlyVideo,
                    ref christianLifeAssignment1Needs, ref christianLifeAssignment1Title, ref christianLifeAssignment1);
                if (findChristianLifeAssignment(ref christianLifeAssignment2OnlyVideo, ref christianLifeAssignment2Needs,
                    ref christianLifeAssignment2Title, ref christianLifeAssignment2) == true)
                {
                    BibleStudy = findName();
                    BibleStudyReader = findName();
                }
                else
                {
                    SupervisorName = findName();
                    Supervisor = true;
                }

            }
            else
            {
                Convention = true;
            }
        }

        private bool findChristianLifeAssignment(ref bool christianLifeAssignmentOnlyVideo,
            ref bool christianLifeAssignmentNeeds, ref string christianLifeAssignmentTitle, ref string christianLifeAssignment)
        {
            christianLifeAssignmentTitle = findTheme();
            if (christianLifeAssignmentTitle == "Necesități locale")
            {
                christianLifeAssignmentNeeds = true;
            }
            else if (christianLifeAssignmentTitle == "Studiul Bibliei în congregație")
            {
                christianLifeAssignmentTitle = null;
                return true;
            }
            else if (christianLifeAssignmentTitle == "Recapitulare, apoi o prezentare scurtă a următoarei întruniri")
            {
                christianLifeAssignmentTitle = null;
                return false;
            }
            christianLifeAssignment = findName();
            if (christianLifeAssignment == President)
            {
                christianLifeAssignmentOnlyVideo = true;
            }
            return true;
        }

        private void findPreachingAssignment(ref string assignmentType,
            ref string assignment, ref string assignmentAssist, string pattern)
        {
            var match = Regex.Match(dataString, pattern);
            if (match != Match.Empty)
            {
                assignmentType = findTheme();
                assignment = findName();
                match = Regex.Match(dataString, "[Vizita][vizită][Studiu][Dedică]");
                if (match != Match.Empty)
                {
                    match = Regex.Match(assignmentType, "Material video");
                    if (match == Match.Empty)
                    {
                        assignmentAssist = find("info", 6);
                    }
                }
            }
        }

        private string findTheme()
        {
            return find("theme", 7, "<");
        }

        private string findName()
        {
            return find("name", 6, "<");
        }

        private string findPrayer(string pattern, int returnIndex)
        {
            return find(pattern, returnIndex, "[)]");
        }

        private string find(string pattern, int returnIndex)
        {
            return find(pattern, returnIndex, "<");
        }

        private string find(string pattern, int returnIndex, string returnEnd)
        {
            var match = Regex.Match(dataString, pattern);
            if (match != Match.Empty)
            {
                dataString = dataString.Substring(match.Index + returnIndex);
                return dataString.Remove(returnEnd);
            }
            return null;
        }
    }
}
