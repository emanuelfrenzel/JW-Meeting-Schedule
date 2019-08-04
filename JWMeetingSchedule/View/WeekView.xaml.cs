using System.ComponentModel;
using System.Windows.Controls;

namespace JWMeetingSchedule.View
{
    public partial class WeekView : UserControl, INotifyPropertyChanged
    {
        public WeekView()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
