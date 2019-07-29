using System;
using Utils;

namespace JWMeetingSchedule.Model
{
    class Person
    {
        public string Name;
        public bool CanMixer;
        public DateTime MixerDate;
        public bool CanMicrophones;
        public DateTime MicrophonesDate;
        public bool CanOrder;
        public DateTime OrderDate;

        public Person(string[] data)
        {
            Name = data[0];
            CanMixer = data[1] == "1";
            MixerDate = DateTime.Parse(data[2],
                          System.Globalization.CultureInfo.InvariantCulture);
            CanMicrophones = data[3] == "1";
            MicrophonesDate = DateTime.Parse(data[4],
                          System.Globalization.CultureInfo.InvariantCulture);
            CanOrder = data[5] == "1";
            OrderDate = DateTime.Parse(data[6],
                          System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
