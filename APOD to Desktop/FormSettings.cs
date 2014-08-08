using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;

namespace APOD_to_Desktop
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        bool isLoading = false;

        /// <summary>
        /// Populate the controls with existing application settings values.
        /// </summary>
        private void FormSettings_Load(object sender, EventArgs e)
        {
            isLoading = true;

            // Set the checkboxes according to program settings.
            if (Properties.Settings.Default.AtLogonGetAPOD)
                checkBoxGetAPOD.CheckState = CheckState.Checked;
            else
                checkBoxGetAPOD.CheckState = CheckState.Unchecked;

            if (Properties.Settings.Default.ContextMenu)
                checkBoxContextMenu.CheckState = CheckState.Checked;
            else
                checkBoxContextMenu.CheckState = CheckState.Unchecked;

            // Set the style combobox dropdown accordingly.
            comboBoxWallpaperStyle.SelectedItem = Properties.Settings.Default.Style;

            // Get the current storage value of the images folder.
            double currentUsage = DirSize(new DirectoryInfo(Properties.Settings.Default.AppFolder));
            if (currentUsage < 1000000000)
                labelCurrentStorage.Text = Convert.ToString((int)currentUsage/1000000) +" MB";
            else
                labelCurrentStorage.Text = Convert.ToString((int)currentUsage/1000000000) +" GB";

            // Increments are 10 MB, 100 MB, 1 GB, 10 GB, 100 GB, Unlimited
            switch ((int)Properties.Settings.Default.MaxUsage)
            {
                case 10:
                    trackBarStorage.Value = 0;
                    labelMaxStorage.Text = "10 MB";
                    break;
                case 100:
                    trackBarStorage.Value = 1;
                    labelMaxStorage.Text = "100 MB";
                    break;
                case 1024:
                    trackBarStorage.Value = 2;
                    labelMaxStorage.Text = "1 GB";
                    break;
                case 10240:
                    trackBarStorage.Value = 3;
                    labelMaxStorage.Text = "10 GB";
                    break;
                case 102400:
                    trackBarStorage.Value = 4;
                    labelMaxStorage.Text = "100 GB";
                    break;
                case 0:
                    trackBarStorage.Value = 5;
                    labelMaxStorage.Text = "Unlimited";
                    break;
            }

            // Create or delete the scheduled task accordingly.
            ManageScheduledTask();

            isLoading = false;
        }

        // Returns the size of a directory including all files and subdirectories within in bytes.
        public static double DirSize(DirectoryInfo d)
        {
            double Size = 0;
            // Add file sizes.
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                Size += fi.Length;
            }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                Size += DirSize(di);
            }
            return (Size);
        }

        private void checkBoxGetAPOD_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            // Adjust settings based on the checkbox values.
            if (checkBoxGetAPOD.CheckState == CheckState.Checked)
                Properties.Settings.Default.AtLogonGetAPOD = true;
            else
                Properties.Settings.Default.AtLogonGetAPOD = false;

            Properties.Settings.Default.Save();

            // Create or delete the scheduled task accordingly.
            ManageScheduledTask();

            Cursor.Current = Cursors.Default;

            
        }

        private void checkBoxContextMenu_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            // Avoid running code if we're just loading the state of the checkbox from user preferences instead of the user making a change.
            if (!isLoading)
            {
                // Adjust settings based on the checkbox values.
                if (checkBoxContextMenu.CheckState == CheckState.Checked)
                    Properties.Settings.Default.ContextMenu = true;
                else
                    Properties.Settings.Default.ContextMenu = false;

                Properties.Settings.Default.Save();

                ManageContextMenu(Properties.Settings.Default.ContextMenu);
            }

            Cursor.Current = Cursors.Default;
        }

        private void comboBoxWallpaperStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the style according to the dropdown combobox value.
            Properties.Settings.Default.Style = comboBoxWallpaperStyle.GetItemText(comboBoxWallpaperStyle.SelectedItem);

            Properties.Settings.Default.Save();
        }

        private void trackBarStorage_Scroll(object sender, EventArgs e)
        {
            // Increments are 10 MB, 100 MB, 1 GB, 10 GB, 100 GB, Unlimited
            switch (trackBarStorage.Value)
            {
                case 0:
                    Properties.Settings.Default.MaxUsage = 10;
                    labelMaxStorage.Text = "10 MB";
                    break;
                case 1:
                    Properties.Settings.Default.MaxUsage = 100;
                    labelMaxStorage.Text = "100 MB";
                    break;
                case 2:
                    Properties.Settings.Default.MaxUsage = 1024;
                    labelMaxStorage.Text = "1 GB";
                    break;
                case 3:
                    Properties.Settings.Default.MaxUsage = 10240;
                    labelMaxStorage.Text = "10 GB";
                    break;
                case 4:
                    Properties.Settings.Default.MaxUsage = 102400;
                    labelMaxStorage.Text = "100 GB";
                    break;
                case 5:
                    Properties.Settings.Default.MaxUsage = 0;
                    labelMaxStorage.Text = "Unlimited";
                    break;
            }

            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Save the settings for APOD to Desktop by creating or deleting a scheduled task.
        /// </summary>
        public void ManageScheduledTask()
        {
            // Set the program to check for new APOD image at logon if the setting is true, otherwise delete any such scheduled tasks.
            if (Properties.Settings.Default.AtLogonGetAPOD)
            {
                // Get the service on the local machine
                using (TaskService ts = new TaskService())
                {
                    // Check for an existing service; if one exists, don't create a new one.
                    try
                    {
                        if (ts.FindTask("APOD to Desktop").IsActive)
                            return;
                    }
                    catch
                    {
                        Console.Write("No task exists.");
                        Console.WriteLine();
                    }

                    // Get the current user name.
                    string user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

                    // Get the path of the application.
                    string appPath = Application.ExecutablePath;

                    // Create a new task definition and assign properties
                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = "Retrieve the APOD and set the desktop wallpaper to it.";
                    td.Principal.UserId = user;

                    // Add a trigger that will fire one minute after logon of the current user; the delay allows time for the PC to connect to the Internet.
                    LogonTrigger lt = new LogonTrigger();
                    lt.Delay = TimeSpan.FromMinutes(1);
                    lt.UserId = user;

                    // Add the trigger to the task.
                    td.Triggers.Add(lt);

                    // Create an action that will launch APOD in Update mode once the trigger fires.
                    td.Actions.Add(new ExecAction(appPath, "UpdateAPOD", null));

                    // Register the task in the root folder
                    ts.RootFolder.RegisterTaskDefinition("APOD to Desktop", td);
                }
            }
            else if (!Properties.Settings.Default.AtLogonGetAPOD)
            {
                // Get the service on the local machine
                using (TaskService ts = new TaskService())
                {
                    try
                    {
                        // Remove the APOD task if it exists.
                        ts.RootFolder.DeleteTask("APOD to Desktop");
                    }
                    catch
                    {
                        Console.Write("No task exists.");
                        Console.WriteLine();
                    }
                }
            }
        }

        /// <summary>
        /// In order to make the necessary registry changes, we need elevated privileges.  Rather than request them each time at startup,
        /// it's less intrusive to launch a new instance of the application with a request for elevation and an argument that only
        /// runs a specific segment of code and then exits.
        /// </summary>
        public void ManageContextMenu(bool addMenu)
        {
            int apodProcNumber = 0;

            // Make sure we don't have too many instances of the application running, to prevent runaway application loops.
            Process[] allProcs = Process.GetProcesses();

            foreach (Process proc in allProcs)
            {
                if (proc.ProcessName.StartsWith("APOD"))
                    apodProcNumber++;
            }

            // If less than two instances are running we're fine with opening a new instance.
            if (apodProcNumber < 3)
            {
                string appPath = Application.ExecutablePath;

                Process apodProc = new Process();

                apodProc.StartInfo.FileName = appPath;
                apodProc.StartInfo.Arguments = addMenu.ToString() + "ContextMenu";
                apodProc.StartInfo.UseShellExecute = true;
                apodProc.StartInfo.Verb = "runas";
                apodProc.Start();
            }
            else if (apodProcNumber >= 3)
            {
                MessageBox.Show("More than one instance of the APOD to Desktop process is currently running, unable to change Context Menu settings.");
                return;
            }
        }

        private void checkForNewAPODToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Program.UpdateAPOD();
            Cursor.Current = Cursors.Default;
        }

        private void openImagesFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Settings.Default.AppFolder);
        }

        private void visitAPODWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://apod.nasa.gov/apod/astropix.html");
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
