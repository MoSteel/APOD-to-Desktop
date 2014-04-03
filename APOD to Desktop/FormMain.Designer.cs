namespace APOD_to_Desktop
{
    partial class FormMain
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
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rTBMain = new System.Windows.Forms.RichTextBox();
            this.buttonCheckAPOD = new System.Windows.Forms.Button();
            this.buttonOpenImgFolder = new System.Windows.Forms.Button();
            this.buttonOpenSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Location = new System.Drawing.Point(12, 30);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(300, 300);
            this.pictureBoxMain.TabIndex = 0;
            this.pictureBoxMain.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(202, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Astronomy Picture Of The Day:";
            // 
            // rTBMain
            // 
            this.rTBMain.Location = new System.Drawing.Point(318, 30);
            this.rTBMain.Name = "rTBMain";
            this.rTBMain.Size = new System.Drawing.Size(300, 300);
            this.rTBMain.TabIndex = 2;
            this.rTBMain.Text = "";
            // 
            // buttonCheckAPOD
            // 
            this.buttonCheckAPOD.Location = new System.Drawing.Point(99, 336);
            this.buttonCheckAPOD.Name = "buttonCheckAPOD";
            this.buttonCheckAPOD.Size = new System.Drawing.Size(140, 23);
            this.buttonCheckAPOD.TabIndex = 3;
            this.buttonCheckAPOD.Text = "Check For New APOD";
            this.buttonCheckAPOD.UseVisualStyleBackColor = true;
            this.buttonCheckAPOD.Click += new System.EventHandler(this.buttonCheckAPOD_Click);
            // 
            // buttonOpenImgFolder
            // 
            this.buttonOpenImgFolder.Location = new System.Drawing.Point(245, 336);
            this.buttonOpenImgFolder.Name = "buttonOpenImgFolder";
            this.buttonOpenImgFolder.Size = new System.Drawing.Size(140, 23);
            this.buttonOpenImgFolder.TabIndex = 4;
            this.buttonOpenImgFolder.Text = "Open Images Folder";
            this.buttonOpenImgFolder.UseVisualStyleBackColor = true;
            this.buttonOpenImgFolder.Click += new System.EventHandler(this.buttonOpenImgFolder_Click);
            // 
            // buttonOpenSettings
            // 
            this.buttonOpenSettings.Location = new System.Drawing.Point(391, 336);
            this.buttonOpenSettings.Name = "buttonOpenSettings";
            this.buttonOpenSettings.Size = new System.Drawing.Size(140, 23);
            this.buttonOpenSettings.TabIndex = 5;
            this.buttonOpenSettings.Text = "Manage Settings";
            this.buttonOpenSettings.UseVisualStyleBackColor = true;
            this.buttonOpenSettings.Click += new System.EventHandler(this.buttonOpenSettings_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 364);
            this.Controls.Add(this.buttonOpenSettings);
            this.Controls.Add(this.buttonOpenImgFolder);
            this.Controls.Add(this.buttonCheckAPOD);
            this.Controls.Add(this.rTBMain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxMain);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APOD to Desktop (Version 0.1 - 2014 April 3)";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rTBMain;
        private System.Windows.Forms.Button buttonCheckAPOD;
        private System.Windows.Forms.Button buttonOpenImgFolder;
        private System.Windows.Forms.Button buttonOpenSettings;
    }
}