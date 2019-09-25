using JWMeetingSchedule.ViewModel;

using System.ComponentModel;
using System.Windows.Controls;

namespace JWMeetingSchedule.View
{
    public partial class WeekView : UserControl, INotifyPropertyChanged
    {
        public WeekView(WeekViewModel weekViewModel)
        {
            InitializeComponent();
            DataContext = weekViewModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
