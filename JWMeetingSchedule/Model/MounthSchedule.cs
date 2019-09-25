﻿//MIT License

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

using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace JWMeetingSchedule.Model
{
    public class MounthSchedule
    {
        private string fileContent;

        public MounthSchedule(string fileName)
        {
            fileContent = File.ReadAllText(fileName);
        }

        public List<WeekSchedule> FindWeeks()
        {
            var weeks = new List<WeekSchedule>();
            foreach (Match match in Regex.Matches(fileContent, "Săptămâna care începe la "))
            {
                var dataString = fileContent.Substring(match.Index + match.Length);
                var week = new WeekSchedule(dataString);
                weeks.Add(week);
            }
            return weeks;
        }
    }
}
