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

using System.Text.RegularExpressions;

namespace JWMeetingSchedule.Model
{
    public class ApplyToMinistrySchedule
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

        public ApplyToMinistrySchedule(ref string dataString)
        {
            this.dataString = dataString;
            findPreachingAssignment(ref assignment1Type, ref assignment1, ref assignment1Assist, "FM Talk 1");
            findPreachingAssignment(ref assignment2Type, ref assignment2, ref assignment2Assist, "FM Talk 2");
            findPreachingAssignment(ref assignment3Type, ref assignment3, ref assignment3Assist, "FM Talk 3");
            findPreachingAssignment(ref assignment4Type, ref assignment4, ref assignment4Assist, "FM Talk 4");
            dataString = this.dataString;
        }

        private void findPreachingAssignment(ref string assignmentType,
         ref string assignment, ref string assignmentAssist, string pattern)
        {
            var match = Regex.Match(dataString, pattern);
            if (match != Match.Empty)
            {
                assignmentType = WeekSchedule.findTheme(ref dataString);
                assignment = WeekSchedule.findName(ref dataString);
                match = Regex.Match(dataString, "[Vizita][vizită][Studiu][Dedică]");
                if (match != Match.Empty)
                {
                    match = Regex.Match(assignmentType, "Material video");
                    if (match == Match.Empty)
                    {
                        assignmentAssist = WeekSchedule.find(ref dataString,"info", 6);
                    }
                }
            }
        }
    }
}
