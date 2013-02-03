using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eclipsis
{
    public partial class EISClientSettings : Form
    {
        public EISClientSettings()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void checkBox_C_Localhost_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_C_Localhost.Checked)
                textBox_C_ServerIPAddress.Text = "127.0.0.1";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
