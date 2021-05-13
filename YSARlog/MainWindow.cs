using System.Windows;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Windows.Input;
using System.Reflection;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Threading;
using System.Timers;
using MessageBox = System.Windows.Forms.MessageBox;
using System.Windows.Controls;

namespace YSARlog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Datas> Users;

        public string Team { get; set; }
        public string Clue { get; set; }
        public string Time { get; set; }
        public string Message { get; set; }
        public string NZTM { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer Timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                DateText.Text = DateTime.Now.ToString("                                                dddd dd/MM/yy   HH:mm:ss");//dateText is the definition in main window (following naming conventions)
            }, Dispatcher);//timeclock in menu bar - bound to DateText

        }//end mainwindow

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }//end 'exit' menu item

        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Datas> Users = new List<Datas>();
            Datas NewUser = new Datas() { Time = "" + DateTime.Now + "", Clue = "", Team = "", Message = "", NZTM = "" };
            Users.Add(NewUser);//create new table with the columns bound to these values in the 'Datas' list

    

            DataGridSar.ItemsSource = Users;

        }//end button click (new table)
        void TB_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Time = ""+ DateTime.Now +"" + Time;
            }

            else
            { }
        }//end KeyDown event (time)

        private void Button_Click_2(object sender, EventArgs e)
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            string FileName = @"C:\YSARLog\Radio Logs\YSARLog " + DateTime.Now.ToString("dd_MM_yyyy HH-mm") + ".txt";//filename

            string FolderName = @"c:\YSARLog";//root folder name
            string PathString = System.IO.Path.Combine(FolderName, "Radio Logs");//subfolder
            System.IO.Directory.CreateDirectory(PathString);//create directory if not existing
            PathString = System.IO.Path.Combine(PathString, FileName);


            IEnumerator enumerator = DataGridSar.ItemsSource.GetEnumerator();

            using (StreamWriter writer = new StreamWriter(FileName))
                while (enumerator.MoveNext())
                {
                    Datas item = (Datas)enumerator.Current;
                    string TextToAdd = $"Log: {item.Time}, is Clue: {item.Clue}, [{item.Team}] {item.Message}, NZTM/6Fig: {item.NZTM}";
                    writer.WriteLine(TextToAdd);

                }//end streamwriter

            

    MessageBox.Show("Saved!" 
                + Environment.NewLine + "Check C:\\YSARLog\\Radio Logs to find the file" 
                + Environment.NewLine + "File Explorer -> This PC -> Windows (C:) -> YSARLog -> Radio Logs");

        }//end button click 2 (save file)

        private void Button_Click_3(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to the YSARLog Program" + Environment.NewLine +
                "To start a new log, click File -> New" + Environment.NewLine +
                "To save the log at the end of the exercsie, click File -> Save" + Environment.NewLine +
               "Please note that clicking save will overwrite the log.txt file. Make sure to make a copy of your previous ones or rename them when you have finished" + Environment.NewLine);

        }//end button click 3 (help box)

        private static System.Timers.Timer aTimer;
        public static void MaintTmer()
        {
            SetTimer();
            aTimer.Stop();
            aTimer.Dispose();
        }
        private static void SetTimer()
        {
            aTimer = new System.Timers.Timer(5000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        { 
            MessageBox.Show("Hello!");
        }


        public class Datas : IEnumerable
        {
            public string Team { get; set; }
            public IEnumerator GetEnumerator()
            {
                return ((IEnumerable)Team).GetEnumerator();
            }
            public string Clue { get; set; }
            public string Time { get; set; }
            //public static DateTime Now { get; set; }
            public string Message { get; set; }
            public string NZTM { get; set; }


        }// end class Datas (bindings to XAML)

    }//end Window

}// end Namespace