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

using JWMeetingSchedule.Model.Schedule;
using System.Globalization;

namespace JWMeetingSchedule.ViewModel
{
    public class WeekViewModel
    {
        private WeekSchedule week;
        public string WeekName {
            get
            {
                var temp = week.WeekStartDate.Day.ToString();
                var endDate = week.WeekStartDate.AddDays(6);
                if(week.WeekStartDate.Month != endDate.Month)
                {
                    temp += " ";
                    temp += week.WeekStartDate.ToString("MMMM", new CultureInfo("ro-RO"));
                }
                temp += " - ";
                temp += endDate.Day.ToString();
                temp += " ";
                temp += endDate.ToString("MMMM", new CultureInfo("ro-RO"));
                return temp;
            }
        }

        public WeekViewModel(WeekSchedule week)
        {
            this.week = week;
        }
    }
}
