using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace JWMeetingSchedule.View
{
    /// <summary>
    /// Interaction logic for ScheduleView.xaml
    /// </summary>
    public partial class ScheduleView : UserControl
    {
        public ScheduleView()
        {
            InitializeComponent();
        }

        private void BtnSelectFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "HTML files (*.html)|*.html";
            openFileDialog.ShowDialog();

        }
    }
}
