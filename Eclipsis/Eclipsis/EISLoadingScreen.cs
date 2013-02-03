using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EISModuleComponents;
using EclipsisTransactionProtocol;
using Eclipsis;

namespace Eclipsis
{
    public partial class EISLoadingScreen : Form
    {
        private string username;
        private string password;
        private SQLRequestProcessor sql_processor;
        private EISModuleHost host;
        private bool debug = true;

        public EISLoadingScreen(SQLRequestProcessor Processor, EISModuleHost Host)
        {
            InitializeComponent();
            sql_processor = Processor;
            host = Host;
            
        }

        public string Password
        {
            set { password = value; }
        }
        public string Username
        {
            set { username = value; }
        }

        public bool processUserLogin(bool notify)
        {
            using (EISCryptoService crypto_service = new EISCryptoService())
            {
                String passwordHash;
                // hash the password
                passwordHash = host.Services.CryptoService.EncryptStringAES(password, host.Services.CryptoService.GetPresharedKey());
                EISTransactionObject request = new EISTransactionObject();
                request.Tablename = " users JOIN hashtable JOIN userdetails ";
                request.ActionType = SQLActionType.Select;
                request.SelectCondition = " name = '" + username + "' " + " AND hash='" + password + "';";
                
                request.Content.Add(new ColValues("name"));
                request.Content.Add(new ColValues("hash"));
                request =  sql_processor.ProcessRequest(request);

                if (request.Content[0].Value.Count == 0 && notify)
                {
                    host.Notify("No user with such name found!", EISErrorTypes.Warning);
                    return debug ? true : false;
                }
                // if hashed password is same as password in database, then proceed
                
                if ((request.Content.Count > 0) && passwordHash == request.Content[0].Value[0])
                    return true;
                    //host.Notify("Sucessfuly logged in!", EISErrorTypes.Information
             }
            return false;
        }


    
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            // process user log in
            if (processUserLogin(true))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            Username = textBoxName.Text;
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            Password = textBoxName.Text;
        }
    }
}
