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

namespace JWMeetingSchedule.Model
{
    public class ChristianLifeSchedule
    {
        private string dataString;
        private string president;
        private bool christianLifeAssignment1OnlyVideo;
        private bool christianLifeAssignment1Needs;
        private string christianLifeAssignment1Title;
        private string christianLifeAssignment1;
        private bool christianLifeAssignment2OnlyVideo;
        private bool christianLifeAssignment2Needs;
        private string christianLifeAssignment2Title;
        private string christianLifeAssignment2;
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

        public ChristianLifeSchedule(ref string dataString, string president, ref bool supervisor)
        {
            this.dataString = dataString;
            this.president = president;
            findChristianLifeAssignment(ref christianLifeAssignment1OnlyVideo, ref christianLifeAssignment1Needs,
                   ref christianLifeAssignment1Title, ref christianLifeAssignment1);
            if (findChristianLifeAssignment(ref christianLifeAssignment2OnlyVideo, ref christianLifeAssignment2Needs,
                ref christianLifeAssignment2Title, ref christianLifeAssignment2) == true)
            {
                BibleStudy = WeekSchedule.findName(ref dataString);
                BibleStudyReader = WeekSchedule.findName(ref dataString);
            }
            else
            {
                SupervisorName = WeekSchedule.findName(ref dataString);
                supervisor = true;
            }
            dataString = this.dataString;
        }

        private bool findChristianLifeAssignment(ref bool christianLifeAssignmentOnlyVideo,
         ref bool christianLifeAssignmentNeeds, ref string christianLifeAssignmentTitle, ref string christianLifeAssignment)
        {
            christianLifeAssignmentTitle = WeekSchedule.findTheme(ref dataString);
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
            christianLifeAssignment = WeekSchedule.findName(ref dataString);
            if (christianLifeAssignment == president)
            {
                christianLifeAssignmentOnlyVideo = true;
            }
            return true;
        }
    }
}
