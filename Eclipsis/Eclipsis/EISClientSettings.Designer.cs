namespace Eclipsis
{
    partial class EISClientSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EISClientSettings));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageGlobal = new System.Windows.Forms.TabPage();
            this.tabPageConnection = new System.Windows.Forms.TabPage();
            this.groupBox_C_Server = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_C_Port = new System.Windows.Forms.MaskedTextBox();
            this.checkBox_C_Localhost = new System.Windows.Forms.CheckBox();
            this.label_C_ServerSocket = new System.Windows.Forms.Label();
            this.textBox_C_ServerIPAddress = new System.Windows.Forms.TextBox();
            this.label_C_ServerIPAddress = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox_C_Database = new System.Windows.Forms.GroupBox();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDatabase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPageConnection.SuspendLayout();
            this.groupBox_C_Server.SuspendLayout();
            this.groupBox_C_Database.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageGlobal);
            this.tabControl.Controls.Add(this.tabPageConnection);
            this.tabControl.Location = new System.Drawing.Point(0, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(356, 456);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageGlobal
            // 
            this.tabPageGlobal.Location = new System.Drawing.Point(4, 22);
            this.tabPageGlobal.Name = "tabPageGlobal";
            this.tabPageGlobal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGlobal.Size = new System.Drawing.Size(348, 430);
            this.tabPageGlobal.TabIndex = 0;
            this.tabPageGlobal.Text = "Global";
            this.tabPageGlobal.UseVisualStyleBackColor = true;
            // 
            // tabPageConnection
            // 
            this.tabPageConnection.Controls.Add(this.groupBox_C_Database);
            this.tabPageConnection.Controls.Add(this.groupBox_C_Server);
            this.tabPageConnection.Location = new System.Drawing.Point(4, 22);
            this.tabPageConnection.Name = "tabPageConnection";
            this.tabPageConnection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConnection.Size = new System.Drawing.Size(348, 430);
            this.tabPageConnection.TabIndex = 1;
            this.tabPageConnection.Text = "Connection";
            this.tabPageConnection.UseVisualStyleBackColor = true;
            // 
            // groupBox_C_Server
            // 
            this.groupBox_C_Server.Controls.Add(this.maskedTextBox_C_Port);
            this.groupBox_C_Server.Controls.Add(this.checkBox_C_Localhost);
            this.groupBox_C_Server.Controls.Add(this.label_C_ServerSocket);
            this.groupBox_C_Server.Controls.Add(this.textBox_C_ServerIPAddress);
            this.groupBox_C_Server.Controls.Add(this.label_C_ServerIPAddress);
            this.groupBox_C_Server.Location = new System.Drawing.Point(8, 6);
            this.groupBox_C_Server.Name = "groupBox_C_Server";
            this.groupBox_C_Server.Size = new System.Drawing.Size(332, 86);
            this.groupBox_C_Server.TabIndex = 0;
            this.groupBox_C_Server.TabStop = false;
            this.groupBox_C_Server.Text = "Server";
            // 
            // maskedTextBox_C_Port
            // 
            this.maskedTextBox_C_Port.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Eclipsis.Properties.Settings.Default, "tcp_port", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.maskedTextBox_C_Port.Location = new System.Drawing.Point(107, 44);
            this.maskedTextBox_C_Port.Mask = "00000";
            this.maskedTextBox_C_Port.Name = "maskedTextBox_C_Port";
            this.maskedTextBox_C_Port.Size = new System.Drawing.Size(103, 20);
            this.maskedTextBox_C_Port.TabIndex = 5;
            this.maskedTextBox_C_Port.Text = global::Eclipsis.Properties.Settings.Default.tcp_port;
            this.maskedTextBox_C_Port.ValidatingType = typeof(int);
            // 
            // checkBox_C_Localhost
            // 
            this.checkBox_C_Localhost.AutoSize = true;
            this.checkBox_C_Localhost.Checked = global::Eclipsis.Properties.Settings.Default.tcp_localhost;
            this.checkBox_C_Localhost.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Eclipsis.Properties.Settings.Default, "tcp_localhost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_C_Localhost.Location = new System.Drawing.Point(216, 19);
            this.checkBox_C_Localhost.Name = "checkBox_C_Localhost";
            this.checkBox_C_Localhost.Size = new System.Drawing.Size(72, 17);
            this.checkBox_C_Localhost.TabIndex = 4;
            this.checkBox_C_Localhost.Text = "Localhost";
            this.checkBox_C_Localhost.UseVisualStyleBackColor = true;
            this.checkBox_C_Localhost.CheckedChanged += new System.EventHandler(this.checkBox_C_Localhost_CheckedChanged);
            // 
            // label_C_ServerSocket
            // 
            this.label_C_ServerSocket.AutoSize = true;
            this.label_C_ServerSocket.Location = new System.Drawing.Point(25, 47);
            this.label_C_ServerSocket.Name = "label_C_ServerSocket";
            this.label_C_ServerSocket.Size = new System.Drawing.Size(76, 13);
            this.label_C_ServerSocket.TabIndex = 2;
            this.label_C_ServerSocket.Text = "Server socket:";
            // 
            // textBox_C_ServerIPAddress
            // 
            this.textBox_C_ServerIPAddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Eclipsis.Properties.Settings.Default, "tcp_server", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_C_ServerIPAddress.Location = new System.Drawing.Point(107, 17);
            this.textBox_C_ServerIPAddress.Name = "textBox_C_ServerIPAddress";
            this.textBox_C_ServerIPAddress.Size = new System.Drawing.Size(103, 20);
            this.textBox_C_ServerIPAddress.TabIndex = 1;
            this.textBox_C_ServerIPAddress.Text = global::Eclipsis.Properties.Settings.Default.tcp_server;
            // 
            // label_C_ServerIPAddress
            // 
            this.label_C_ServerIPAddress.AutoSize = true;
            this.label_C_ServerIPAddress.Location = new System.Drawing.Point(7, 20);
            this.label_C_ServerIPAddress.Name = "label_C_ServerIPAddress";
            this.label_C_ServerIPAddress.Size = new System.Drawing.Size(94, 13);
            this.label_C_ServerIPAddress.TabIndex = 0;
            this.label_C_ServerIPAddress.Text = "Server IP address:";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(188, 473);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(269, 473);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox_C_Database
            // 
            this.groupBox_C_Database.Controls.Add(this.textBoxServer);
            this.groupBox_C_Database.Controls.Add(this.textBoxPassword);
            this.groupBox_C_Database.Controls.Add(this.label4);
            this.groupBox_C_Database.Controls.Add(this.textBoxUser);
            this.groupBox_C_Database.Controls.Add(this.label3);
            this.groupBox_C_Database.Controls.Add(this.textBoxDatabase);
            this.groupBox_C_Database.Controls.Add(this.label2);
            this.groupBox_C_Database.Controls.Add(this.label1);
            this.groupBox_C_Database.Location = new System.Drawing.Point(8, 98);
            this.groupBox_C_Database.Name = "groupBox_C_Database";
            this.groupBox_C_Database.Size = new System.Drawing.Size(332, 134);
            this.groupBox_C_Database.TabIndex = 1;
            this.groupBox_C_Database.TabStop = false;
            this.groupBox_C_Database.Text = "Database";
            // 
            // textBoxServer
            // 
            this.textBoxServer.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Eclipsis.Properties.Settings.Default, "sqlserver", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxServer.Location = new System.Drawing.Point(107, 19);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(171, 20);
            this.textBoxServer.TabIndex = 20;
            this.textBoxServer.Text = global::Eclipsis.Properties.Settings.Default.sqlserver;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Eclipsis.Properties.Settings.Default, "passw", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxPassword.Location = new System.Drawing.Point(107, 97);
            this.textBoxPassword.MaxLength = 64;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(171, 20);
            this.textBoxPassword.TabIndex = 19;
            this.textBoxPassword.Text = global::Eclipsis.Properties.Settings.Default.passw;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Password:";
            // 
            // textBoxUser
            // 
            this.textBoxUser.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Eclipsis.Properties.Settings.Default, "userid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxUser.Location = new System.Drawing.Point(107, 71);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(171, 20);
            this.textBoxUser.TabIndex = 17;
            this.textBoxUser.Text = global::Eclipsis.Properties.Settings.Default.userid;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "User ID:";
            // 
            // textBoxDatabase
            // 
            this.textBoxDatabase.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Eclipsis.Properties.Settings.Default, "database", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxDatabase.Location = new System.Drawing.Point(107, 45);
            this.textBoxDatabase.Name = "textBoxDatabase";
            this.textBoxDatabase.Size = new System.Drawing.Size(171, 20);
            this.textBoxDatabase.TabIndex = 15;
            this.textBoxDatabase.Text = global::Eclipsis.Properties.Settings.Default.database;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Database:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Server address:";
            // 
            // EISClientSettings
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(356, 508);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EISClientSettings";
            this.Text = "EISClientSettings";
            this.tabControl.ResumeLayout(false);
            this.tabPageConnection.ResumeLayout(false);
            this.groupBox_C_Server.ResumeLayout(false);
            this.groupBox_C_Server.PerformLayout();
            this.groupBox_C_Database.ResumeLayout(false);
            this.groupBox_C_Database.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageGlobal;
        private System.Windows.Forms.TabPage tabPageConnection;
        private System.Windows.Forms.GroupBox groupBox_C_Server;
        private System.Windows.Forms.Label label_C_ServerIPAddress;
        private System.Windows.Forms.TextBox textBox_C_ServerIPAddress;
        private System.Windows.Forms.Label label_C_ServerSocket;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBox_C_Localhost;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_C_Port;
        private System.Windows.Forms.GroupBox groupBox_C_Database;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDatabase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}