using System.Collections.Generic;
using System.IO;

namespace JWMeetingSchedule.Model
{
    class PeopleList
    {
        public List<Person> persons;

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

        }
    }
}
