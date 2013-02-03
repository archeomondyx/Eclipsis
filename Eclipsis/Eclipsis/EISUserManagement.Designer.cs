namespace Eclipsis
{
    partial class EISUserManagement
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EISUserManagement));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageUserList = new System.Windows.Forms.TabPage();
           
            this.tabPageNewUsers = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
           
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageUserList);
            this.tabControl1.Controls.Add(this.tabPageNewUsers);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(677, 418);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageUserList
            // 
            this.tabPageUserList.Location = new System.Drawing.Point(4, 22);
            this.tabPageUserList.Name = "tabPageUserList";
            this.tabPageUserList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUserList.Size = new System.Drawing.Size(669, 392);
            this.tabPageUserList.TabIndex = 0;
            this.tabPageUserList.Text = "Users";
            this.tabPageUserList.UseVisualStyleBackColor = true;
            // 
            // tabPageNewUsers
            // 
            this.tabPageNewUsers.Location = new System.Drawing.Point(4, 22);
            this.tabPageNewUsers.Name = "tabPageNewUsers";
            this.tabPageNewUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNewUsers.Size = new System.Drawing.Size(669, 392);
            this.tabPageNewUsers.TabIndex = 1;
            this.tabPageNewUsers.Text = "NewUser";
            this.tabPageNewUsers.UseVisualStyleBackColor = true;
            // 
            // EISUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 418);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EISUserManagement";
            this.Text = "User Management";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageUserList;
        private System.Windows.Forms.TabPage tabPageNewUsers;

    }
}