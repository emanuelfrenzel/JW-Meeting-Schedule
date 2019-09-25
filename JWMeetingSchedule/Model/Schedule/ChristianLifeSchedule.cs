//MIT License

//Copyright (c) 2019 Emanuel Frenzel

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

namespace JWMeetingSchedule.Model.Schedule
{
    public class ChristianLifeSchedule
    {
        private string dataString;
        private string president;
        private bool assignment1OnlyVideo;
        private bool assignment1Needs;
        private string assignment1Title;
        private string assignment1;
        private bool assignment2OnlyVideo;
        private bool assignment2Needs;
        private string assignment2Title;
        private string assignment2;
        public bool Assignment1OnlyVideo => assignment1OnlyVideo;
        public bool Assignment1Needs => assignment1Needs;
        public string Assignment1Title => assignment1Title;
        public string Assignment1 => assignment1;
        public bool Assignment2OnlyVideo => assignment2OnlyVideo;
        public bool Assignment2Needs => assignment2OnlyVideo;
        public string Assignment2Title => assignment2Title;
        public string Assignment2 => assignment2;
        public string BibleStudy { get; set; }
        public string BibleStudyReader { get; set; }
        public string Prayer { get; set; }

        public ChristianLifeSchedule(ref string dataString, ref bool supervisor, ref string supervisorName, string president)
        {
            this.dataString = dataString;
            this.president = president;
            findAssignment(ref assignment1OnlyVideo, ref assignment1Needs, ref assignment1Title, ref assignment1);
            if (findAssignment(ref assignment2OnlyVideo, ref assignment2Needs, ref assignment2Title, ref assignment2) == true)
            {
                BibleStudy = WeekSchedule.findName(ref dataString);
                if (BibleStudy == "Recapitulare, apoi o prezentare scurtă a următoarei întruniri")
                {
                    BibleStudy = null;
                    supervisorName = WeekSchedule.findName(ref dataString);
                    supervisor = true;
                }
                else
                {
                    BibleStudyReader = WeekSchedule.findName(ref dataString);
                }
            }
            else
            {
                supervisorName = WeekSchedule.findName(ref dataString);
                supervisor = true;
            }
            dataString = this.dataString;
        }

        private bool findAssignment(ref bool assignmentOnlyVideo,
            ref bool assignmentNeeds, ref string assignmentTitle, ref string assignment)
        {
            assignmentTitle = WeekSchedule.findTheme(ref dataString);
            if (assignmentTitle == "Necesități locale")
            {
                assignmentNeeds = true;
            }
            else if (assignmentTitle == "Studiul Bibliei în congregație")
            {
                assignmentTitle = null;
                return true;
            }
            else if (assignmentTitle == "Recapitulare, apoi o prezentare scurtă a următoarei întruniri")
            {
                assignmentTitle = null;
                return false;
            }
            assignment = WeekSchedule.findName(ref dataString);
            if (assignment == president)
            {
                assignmentOnlyVideo = true;
            }
            return true;
        }
    }
}
