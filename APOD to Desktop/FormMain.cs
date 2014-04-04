using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace APOD_to_Desktop
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void buttonOpenImgFolder_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Settings.Default.AppFolder);
        }

        private void buttonCheckAPOD_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Program.UpdateAPOD();
            Cursor.Current = Cursors.Default;
        }

        private void buttonOpenSettings_Click(object sender, EventArgs e)
        {
            FormSettings fs = new FormSettings();
            fs.Show();
            fs.Location = new Point(this.Location.X + 25, this.Location.Y + 25);
        }

    }
}
