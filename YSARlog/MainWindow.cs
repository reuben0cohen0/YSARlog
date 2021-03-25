using System.Windows;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


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
        }//end mainwindow

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<datas> users = new List<datas>();
            users.Add(new datas() { team = "", time = "", message = "" });

            DataGridSar.ItemsSource = users;
        }//end button click

        private class datas
        {
            public string team { get; set; }
            public string time { get; set; }
            public string message { get; set; }
        }
    }//end window
       


}// end namespace