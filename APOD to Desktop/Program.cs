using System;
using System.ServiceProcess;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;

namespace APOD_to_Desktop
{
    public enum Style : int
    {
        Tile,
        Center,
        Stretch,
        Fit,
        Fill
    }

    class Program
    {
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://apod.nasa.gov/apod/astropix.html"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            // Check if the startup setting has been changed; if True, make a startup key, if false, delete any existing startup keys.
            if (Properties.Settings.Default.RunAtStartup)
            {
                // Get the service on the local machine
                using (TaskService ts = new TaskService())
                {
                    // Get the current user name.
                    string user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

                    // Get the path of the application.
                    string appPath = Application.ExecutablePath;

                    // Create a new task definition and assign properties
                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = "Retrieve the APOD and set the desktop wallpaper to it.";
                    td.Principal.UserId = "SYSTEM";

                    // Add a trigger that will fire one minute after logon of the current user; the delay allows time for the PC to connect to the Internet.
                    LogonTrigger lt = new LogonTrigger();
                    lt.Delay = TimeSpan.FromMinutes(1);
                    lt.UserId = user;

                    // Add the trigger to the task.
                    td.Triggers.Add(lt);

                    // Create an action that will launch APOD once the trigger fires.
                    td.Actions.Add(new ExecAction(appPath, null, null));

                    // Register the task in the root folder
                    ts.RootFolder.RegisterTaskDefinition("APOD to Desktop", td);
                }
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                rk.SetValue("APOD_to_Desktop", Application.ExecutablePath.ToString());
            }
            else if (!Properties.Settings.Default.RunAtStartup)
            {
                // Get the service on the local machine
                using (TaskService ts = new TaskService())
                {
                    // Remove the APOD task.
                    ts.RootFolder.DeleteTask("APOD to Desktop");
                }
            }

            // Try to get the image every ten seconds over a 2 minute time span.
            for (int i = 0; i < 12; i++)
            {
                Console.Write("Cycle number: " + i.ToString());
                Console.WriteLine();

                // Wait to see if a network is up before running through the application.
                if (CheckForInternetConnection())
                {
                    // Check if we should get a new wallpaper or not.
                    if (Properties.Settings.Default.GetWallpaper)
                    {
                        try
                        {
                            GetApod.FindApodImage();
                            DateTime today = DateTime.Today;
                            DesktopManager.Set("apod_" + today.ToString("d").Replace("/", "_") + ".jpg");

                            Console.Write("New wallpaper set.");
                            Console.WriteLine();
                            Console.Read();
                            return;
                        }
                        catch
                        {
                            Console.Write("An error occurred.");
                            Console.WriteLine();
                        }
                    }


                }

                // Put the application to sleep for ten seconds.
                Console.Write("Sleeping 10 seconds...");
                Console.WriteLine();
                Thread.Sleep(10000);
            }
        }
    }
}
