using System.Windows;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Input;
using System.Windows.Threading;

namespace YSARlog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Datas> users;

        public string Team { get; set; }
        public string Clue { get; set; }
        public string Time { get;  set; }
        public string Message { get; set; }
        public string NZTM { get; set; }

    public MainWindow()
        {
            InitializeComponent();

                DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                {
                    this.dateText.Text = DateTime.Now.ToString("                                                dddd dd/MM/yy   HH:mm:ss");
                }, this.Dispatcher);

        }//end mainwindow

        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Datas> users = new List<Datas>();
            Datas newUser = new Datas() { Time = "" + DateTime.Now + "", Clue = "", Team = "", Message = "", NZTM = "" };
            users.Add(newUser);


            DataGridSar.ItemsSource = users;

        }//end button click

        private void Button_Click_2(object sender, EventArgs e)
        {
            string fileName = @"C:\Users\r.d.cohen\source\repos\YSARlog\YSARlog\log.txt";
            string textToAdd = "test";

            IEnumerator enumerator = DataGridSar.ItemsSource.GetEnumerator();
            //enumerator.MoveNext();
            //Datas item = (Datas) enumerator.Current;
            //textToAdd = item.Team;
            using (StreamWriter writer = new StreamWriter(fileName))
            while (enumerator.MoveNext())
            {
                Datas item = (Datas) enumerator.Current;
                textToAdd = $"Log: {item.Time}, {item.Clue}, {item.Team}, {item.Message}, {item.NZTM}";
                
                writer.WriteLine(textToAdd);
            }//end streamwriter
            System.Windows.Forms.MessageBox.Show("Saved!");



        }//end button click 2

        private void Button_Click_3(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Welcome to the YSARLog Program" + Environment.NewLine +
                "To start a new log, click File -> New" + Environment.NewLine +
                "To save the log at the end of the exercsie, click File -> Save" + Environment.NewLine +
               "Please note that clicking save will overwrite the log.txt file. Make sure to make a copy of your previous ones or rename them when you have finished" + Environment.NewLine);
      
        }//end button click 3

        public class Datas : IEnumerable
        {
            public string Team { get; set; }
            public IEnumerator GetEnumerator()
            {
                return ((IEnumerable)Team).GetEnumerator();
            }
            public string Clue {get; set;}
            public string Time { get; set; }
            public string Message { get; set; }
            public string NZTM { get; set; }

        }// end class datas

    }//end window

}// end namespace