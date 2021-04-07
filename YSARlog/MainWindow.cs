using System.Windows;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text;


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
            List<datas> users = new List<datas>();
            users.Add(new datas() { Team = "", Time = "" + DateTime.Now + "", Message = "" });

            string fileName = "log.txt";
            string textToAdd = "";

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.Write(textToAdd);
            }

        }//end mainwindow

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<datas> users = new List<datas>();
            users.Add(new datas() { Team = "", Time = ""+ DateTime.Now +"", Message = "" });

            DataGridSar.ItemsSource = users;

        }//end button click

        private void Button_Click_2(object sender, EventArgs e)
        {
            string fileName = @"C:\Users\r.d.cohen\source\repos\YSARlog\YSARlog\log.txt";
            string textToAdd = ($"Log: {Team}");

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.Write(textToAdd);
            }
        }


        private class datas
        {
            public string Team { get; set; }
            public string Time { get; set; }
            public string Message { get; set; }
        }

    }//end window
       


}// end namespace