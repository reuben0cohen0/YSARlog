using System.Windows;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Reflection;


namespace YSARlog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Datas> users;

        public string Team { get; set; }
        public string Time { get;  set; }
        public string Message { get; set; }

    public MainWindow()
        {
            InitializeComponent();

        }//end mainwindow

        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Datas> users = new List<Datas>();
            Datas newUser = new Datas() { Team = "", Time = "" + DateTime.Now + "", Message = "" };
            users.Add(newUser);


            DataGridSar.ItemsSource = users;

        }//end button click

        private void Button_Click_2(object sender, EventArgs e)
        {
            string fileName = @"C:\Users\r.d.cohen\source\repos\YSARlog\YSARlog\log.txt";
            string textToAdd = "test";

            IEnumerator enumerator = DataGridSar.ItemsSource.GetEnumerator();
            enumerator.MoveNext();
            Datas item = (Datas) enumerator.Current;
            textToAdd = item.Team;
            /*
            while (enumerator.MoveNext())
            {
                object item = enumerator.Current;
                textToAdd = $"Log: {item[0]}";
            }
           */

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.Write(textToAdd);
            }
        }
        public class Datas : IEnumerable
        {
            public string Team { get; set; }
            public IEnumerator GetEnumerator()
            {
                return ((IEnumerable)Team).GetEnumerator();
            }
            public string Time { get; set; }
            public string Message { get; set; }

        }

    }//end window

}// end namespace