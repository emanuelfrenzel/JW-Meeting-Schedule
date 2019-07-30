using JWMeetingSchedule.Model;

using System.Collections.Generic;
using System.IO;

namespace JWMeetingSchedule.ViewModel
{
    class PeopleList
    {
        public List<Person> persons;
        public List<string> MixerPeople;

        public PeopleList()
        {
            persons = new List<Person>();
            readCsv();
        }

        private void readCsv()
        {
            var reader = new StreamReader(@"persons.csv");
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                persons.Add(new Person(values));
            }
            MixerPeople = new List<string> { "fgfhg", "fbcgbc" };
        }
    }
}
