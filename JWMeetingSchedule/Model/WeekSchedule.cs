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

using Utils;

using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace JWMeetingSchedule.Model
{
    public class WeekSchedule
    {
        private string dataString;
        private bool supervisor;
        public DateTime WeekStartDate { get; set; }
        public DateTime WeekMeetingDateTime { get; set; }
        public bool Convention { get; set; }
        public bool Memorial { get; set; }
        public string ExtraInfo { get; set; }
        public bool Supervisor => supervisor;
        public string WeekPresident { get; set; }
        public TreasuresSchedule Treasures { get; set; }
        public ApplyToMinistrySchedule ApplyToMinistry { get; set; }
        public ChristianLifeSchedule ChristianLife { get; set; }
        public WeekendMeetingSchedule WeekendMeeting { get; set; }
        public ResponsibilitiesSchedule Responsibilities { get; set; }

        public WeekSchedule(string dataString)
        {
            this.dataString = dataString.Remove("END OF");
            WeekStartDate = DateTime.Parse(dataString.Remove(10), new CultureInfo("ro-Ro"));
            WeekPresident = findPrayer();
            if (WeekPresident != null)
            {
                Treasures = new TreasuresSchedule(ref dataString);
                ApplyToMinistry = new ApplyToMinistrySchedule(ref dataString);
                ChristianLife = new ChristianLifeSchedule(ref dataString, WeekPresident, ref supervisor);
            }
            else
            {
                Convention = true;
            }
        }

        internal static string findTheme(ref string dataString)
        {
            return find(ref dataString, "theme", 7, "<");
        }

        internal static string findName(ref string dataString)
        {
            return find(ref dataString, "name", 6, "<");
        }

        private string findPrayer()
        {
            return find(ref this.dataString, "Rugăciune ", 30, "[)]");
        }

        internal static string find(ref string dataString, string pattern, int returnIndex)
        {
            return find(ref dataString, pattern, returnIndex, "<");
        }

        private static string find(ref string dataString, string pattern, int returnIndex, string returnEnd)
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
