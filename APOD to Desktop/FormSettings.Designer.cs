namespace APOD_to_Desktop
{
    partial class FormSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxCheckUpdates = new System.Windows.Forms.CheckBox();
            this.checkBoxGetAPOD = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxWallpaperStyle = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelMaxStorage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelCurrentStorage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarStorage = new System.Windows.Forms.TrackBar();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForNewAPODToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImagesFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visitAPODWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStorage)).BeginInit();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxCheckUpdates);
            this.groupBox1.Controls.Add(this.checkBoxGetAPOD);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 67);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Settings";
            // 
            // checkBoxCheckUpdates
            // 
            this.checkBoxCheckUpdates.AutoSize = true;
            this.checkBoxCheckUpdates.Checked = true;
            this.checkBoxCheckUpdates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCheckUpdates.Location = new System.Drawing.Point(6, 42);
            this.checkBoxCheckUpdates.Name = "checkBoxCheckUpdates";
            this.checkBoxCheckUpdates.Size = new System.Drawing.Size(313, 17);
            this.checkBoxCheckUpdates.TabIndex = 7;
            this.checkBoxCheckUpdates.Text = "Automatically check for newer versions of APOD to Desktop.";
            this.checkBoxCheckUpdates.UseVisualStyleBackColor = true;
            this.checkBoxCheckUpdates.CheckedChanged += new System.EventHandler(this.checkBoxCheckUpdates_CheckedChanged);
            // 
            // checkBoxGetAPOD
            // 
            this.checkBoxGetAPOD.AutoSize = true;
            this.checkBoxGetAPOD.Checked = true;
            this.checkBoxGetAPOD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGetAPOD.Location = new System.Drawing.Point(6, 19);
            this.checkBoxGetAPOD.Name = "checkBoxGetAPOD";
            this.checkBoxGetAPOD.Size = new System.Drawing.Size(267, 17);
            this.checkBoxGetAPOD.TabIndex = 6;
            this.checkBoxGetAPOD.Text = "Automatically check for new APOD image at logon.";
            this.checkBoxGetAPOD.UseVisualStyleBackColor = true;
            this.checkBoxGetAPOD.CheckedChanged += new System.EventHandler(this.checkBoxGetAPOD_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.comboBoxWallpaperStyle);
            this.groupBox2.Location = new System.Drawing.Point(12, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(351, 77);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Wallpaper Style";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Select a style format:";
            // 
            // comboBoxWallpaperStyle
            // 
            this.comboBoxWallpaperStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWallpaperStyle.FormattingEnabled = true;
            this.comboBoxWallpaperStyle.Items.AddRange(new object[] {
            "Fill",
            "Stretch",
            "Tile",
            "Center",
            "Fit"});
            this.comboBoxWallpaperStyle.Location = new System.Drawing.Point(6, 40);
            this.comboBoxWallpaperStyle.Name = "comboBoxWallpaperStyle";
            this.comboBoxWallpaperStyle.Size = new System.Drawing.Size(121, 21);
            this.comboBoxWallpaperStyle.TabIndex = 0;
            this.comboBoxWallpaperStyle.SelectedIndexChanged += new System.EventHandler(this.comboBoxWallpaperStyle_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelMaxStorage);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.labelCurrentStorage);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.trackBarStorage);
            this.groupBox3.Location = new System.Drawing.Point(12, 183);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(351, 96);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Storage Settings";
            // 
            // labelMaxStorage
            // 
            this.labelMaxStorage.Location = new System.Drawing.Point(98, 72);
            this.labelMaxStorage.Name = "labelMaxStorage";
            this.labelMaxStorage.Size = new System.Drawing.Size(247, 13);
            this.labelMaxStorage.TabIndex = 4;
            this.labelMaxStorage.Text = "Unlimited";
            this.labelMaxStorage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Max Usage:";
            // 
            // labelCurrentStorage
            // 
            this.labelCurrentStorage.AutoSize = true;
            this.labelCurrentStorage.Location = new System.Drawing.Point(95, 20);
            this.labelCurrentStorage.Name = "labelCurrentStorage";
            this.labelCurrentStorage.Size = new System.Drawing.Size(32, 13);
            this.labelCurrentStorage.TabIndex = 2;
            this.labelCurrentStorage.Text = "0 MB";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Usage:";
            // 
            // trackBarStorage
            // 
            this.trackBarStorage.LargeChange = 1;
            this.trackBarStorage.Location = new System.Drawing.Point(89, 40);
            this.trackBarStorage.Maximum = 5;
            this.trackBarStorage.Name = "trackBarStorage";
            this.trackBarStorage.Size = new System.Drawing.Size(262, 45);
            this.trackBarStorage.TabIndex = 0;
            this.trackBarStorage.Value = 5;
            this.trackBarStorage.Scroll += new System.EventHandler(this.trackBarStorage_Scroll);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(375, 24);
            this.menuStripMain.TabIndex = 9;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForNewAPODToolStripMenuItem,
            this.openImagesFolderToolStripMenuItem,
            this.visitAPODWebsiteToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // checkForNewAPODToolStripMenuItem
            // 
            this.checkForNewAPODToolStripMenuItem.Name = "checkForNewAPODToolStripMenuItem";
            this.checkForNewAPODToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.checkForNewAPODToolStripMenuItem.Text = "Check For APOD Now";
            this.checkForNewAPODToolStripMenuItem.Click += new System.EventHandler(this.checkForNewAPODToolStripMenuItem_Click);
            // 
            // openImagesFolderToolStripMenuItem
            // 
            this.openImagesFolderToolStripMenuItem.Name = "openImagesFolderToolStripMenuItem";
            this.openImagesFolderToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.openImagesFolderToolStripMenuItem.Text = "Open Images Folder";
            this.openImagesFolderToolStripMenuItem.Click += new System.EventHandler(this.openImagesFolderToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // visitAPODWebsiteToolStripMenuItem
            // 
            this.visitAPODWebsiteToolStripMenuItem.Name = "visitAPODWebsiteToolStripMenuItem";
            this.visitAPODWebsiteToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.visitAPODWebsiteToolStripMenuItem.Text = "Visit APOD Website";
            this.visitAPODWebsiteToolStripMenuItem.Click += new System.EventHandler(this.visitAPODWebsiteToolStripMenuItem_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 288);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APOD to Desktop (Version 0.2 - 2014 April 5)";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStorage)).EndInit();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxCheckUpdates;
        private System.Windows.Forms.CheckBox checkBoxGetAPOD;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBoxWallpaperStyle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelMaxStorage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelCurrentStorage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarStorage;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForNewAPODToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImagesFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visitAPODWebsiteToolStripMenuItem;
    }
}