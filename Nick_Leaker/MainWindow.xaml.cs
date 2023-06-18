using Indieteur.GlobalHooks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Clipboard = System.Windows.Clipboard;
using MessageBox = System.Windows.MessageBox;

namespace Nick_Leaker
{
    public partial class MainWindow : Window
    {
        GlobalKeyHook keyHook = new GlobalKeyHook();

        public MainWindow()
        {
            InitializeComponent();
            this.Hide();
            keyHook.OnKeyDown += KeyHook_OnKeyDown;
            var p = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            if (p.Length > 1)
            {
                Thread.Sleep(2000);
            }
            Thread thread = new Thread(KillOtherInstances);
            thread.Start();
            this.Show();
        }


        private void KillOtherInstances()
        {
            while (true)
            {
                Thread.Sleep(800);
                Process current = Process.GetCurrentProcess();
                foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                {
                    if (process.Id != current.Id)
                    {
                        Dispatcher.BeginInvoke(new Action(() => this.Show()));
                        Dispatcher.BeginInvoke(new Action(() => this.Activate()));
                        process.Kill();
                        break;
                    }
                }
            } 
        }

        private void KeyHook_OnKeyDown(object sender, GlobalKeyEventArgs e)
        {
            if(e.KeyCode == VirtualKeycodes.L)
            {
                if(Keyboard.IsKeyDown(Key.LeftCtrl))
                {
                    Task.Delay(80);
                    SendKeys.SendWait("^a");
                    Task.Delay(80);
                    SendKeys.SendWait("^x");
                    string name = Clipboard.GetText();
					//CENSORED TO PROTECT EXPLOIT

                    if (//CENSORED TO PROTECT EXPLOIT)
                    {
                      //CENSORED TO PROTECT EXPLOIT
                        Clipboard.SetText("Un-Nicked name: " + username);
                        SendKeys.SendWait("^a");
                        Task.Delay(80);
                        SendKeys.SendWait("^v");
                    }
                    else
                    {
                        Clipboard.SetText("Error, could not fetch the desired name.");
                        SendKeys.SendWait("^v");
                    }
                }
            }
        }

        private string GetRequest(string url, int i)
        {
			//CENSORED TO PROTECT EXPLOIT
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            var res = MessageBox.Show("Click 'Yes' to leave the application running in the background\n\nClick 'No' to exit it.", "Exit?", MessageBoxButton.YesNo);
            if(res == MessageBoxResult.No)
            {
                Environment.Exit(Environment.ExitCode);
            }
            else
            {
                this.Hide();
            }
        }
    }
}
