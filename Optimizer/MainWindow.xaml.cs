using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Diagnostics;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2DrisnyaGame
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private string[] text_script = new string[25] { "@echo off", "sc config WerSvc start= disabled", "net stop WerSvc", "sc config WbioSrvc start= disabled ", "net stop WbioSrvc", "sc config TabletInputService start= disabled", "net stop TabletInputService", "sc config TrkWks start= disabled", "net stop TrkWks", "sc config PcaSvc start= disabled", "net stop PcaSvc", "sc config RemoteRegistry start= disabled", "net stop RemoteRegistry", "sc config dmwappushservice start= disabled ", "net stop dmwappushservice", "net stop SysMain", "sc config SysMain start= disabled", "if errorlevel 1 goto first", "if errorlevel 0 goto second", ":first", "exit", ":second", "cd /d \"% ~dp0\"", "echo true>>file.txt", "exit"};
        private List<string> actions = new List<string> { "@echo off", "sc config WerSvc start= disabled", "net stop WerSvc", "sc config WbioSrvc start= disabled ", "net stop WbioSrvc", "sc config TabletInputService start= disabled", "net stop TabletInputService", "sc config TrkWks start= disabled", "net stop TrkWks", "sc config PcaSvc start= disabled", "net stop PcaSvc", "sc config RemoteRegistry start= disabled", "net stop RemoteRegistry", "sc config dmwappushservice start= disabled ", "net stop dmwappushservice", "net stop SysMain", "sc config SysMain start= disabled", "if errorlevel 1 goto first", "if errorlevel 0 goto second", ":first", "exit", ":second", "cd /d \"% ~dp0\"", "echo true>>file.txt", "exit" };
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool check(string str)
        {
            if (File.Exists(str))
                return true;
            else
                return false;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {

            if (File.Exists("scr.txt"))
            {
                using (StreamReader script_read = new StreamReader("scr.txt"))
                {
                    actions.RemoveRange(0, actions.Count);
                    while (!script_read.EndOfStream)
                    {
                        actions.Add(script_read.ReadLine());
                    }
                }
            }
                using (StreamWriter script = new StreamWriter("scr.bat"))
            {
               
                for (int i = 0; i < actions.Count; i++)
                {
                    script.WriteLine(actions[i]);
                }
            }


            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "scr.bat";
            start.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            Process scr = new Process();
            scr.StartInfo = start;
            scr.Start();
            scr.WaitForExit();
            File.Delete("scr.bat");
            if (check("file.txt"))
            {
                checker1.Fill = Brushes.Green;
                File.Delete("file.txt");
            }
        }
    }
}

