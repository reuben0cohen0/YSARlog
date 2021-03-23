using System.Windows;

namespace YSARlog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var data = new Log { team = "team", time = "time", message = "message" };

            DataGridSar.Items.Add(data);
        }
    }

    public class Log
    {
        public string team { get; set; }
        public string time { get; set; }
        public string message { get; set; }
    } 

}