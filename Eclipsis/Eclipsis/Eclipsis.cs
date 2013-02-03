using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EISModuleComponents;

namespace Eclipsis
{
    public partial class Eclipsis : Form, EISModuleHost
    {
        # region Fields
        Types.AvailableEISModule currentModule;
       
        string pathToModules;
        # endregion
        
        public Eclipsis()
        { 
            InitializeComponent();
        }
        private void Eclipsis_Load(object sender, EventArgs e)
        {
            try
            {
                EISLoadingScreen scr = new EISLoadingScreen(EISMetaLayer.SQLProcessor, this);
                if (scr.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    this.Close();

                pathToModules = Application.StartupPath + @"\Modules";
                loadModules(pathToModules, true);
            }
            catch (Exception ex)
            {
                Notify(ex.Message, EISErrorTypes.Warning);
            }

        }

        # region Module management

        private void reloadModule()
        {
            if (toolStripComboBoxModules.Items.Count > 0 && toolStripComboBoxModules.SelectedItem != null)
            {
                
                Types.AvailableEISModule selectedModule = EISMetaLayer.Modules.AllAvailableModules.Find(toolStripComboBoxModules.SelectedItem.ToString());
                if (selectedModule == null)
                    return;

                selectedModule.Instance.HostModule = this;
                selectedModule.Instance.MainInterface.Dock = DockStyle.Fill;
                currentModule = selectedModule;

                this.mainPanel.Controls.Clear();
                this.mainPanel.Controls.Add(currentModule.Instance.MainInterface);


            }
        }
        private void loadModules(string path, bool shouldClearModules)
        {
            try
            {
                if (shouldClearModules)
                    EISMetaLayer.Modules.CloseModules();

                EISMetaLayer.Modules.FindModules(path);

                foreach (Types.AvailableEISModule eismodule in EISMetaLayer.Modules.AllAvailableModules)
                {
                    toolStripComboBoxModules.Items.Add(eismodule.Instance.ModuleName);
                }
                if (toolStripComboBoxModules.Items.Count > 0)
                {
                    toolStripComboBoxModules.SelectedIndex = 0;
                    reloadModule();
                }
            }
            catch (Exception exc)
            {
                Notify(exc.Message, EISErrorTypes.Warning);
            }
        }

        # endregion

        # region EISModule host implementation
        # region User notification methods
        // client's progress bar
        public ToolStripProgressBar Progressbar
        {
            get { return progressBar; }
        }

        public void Notify(string ErrorMessage, EISErrorTypes ErrorType)
        {
            // todo
            switch (ErrorType)
            {
                case EISErrorTypes.Error:
                    MessageBox.Show(ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case EISErrorTypes.Warning:
                    MessageBox.Show(ErrorMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case EISErrorTypes.Information:
                    MessageBox.Show(ErrorMessage, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case EISErrorTypes.Message:
                    MessageBox.Show(ErrorMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
            }
        }

        public void SetStatus(string status)
        {
            if (status != null && status != String.Empty)
                statusStrip.Text = status;
        }

        # endregion

        public GlobalServices Services
        {
            get { return EISMetaLayer.Services; }
        }

        public void WriteToLog(string message)
        {
           // todo
        }
        # endregion
        
        # region Common module function calls
        private void backToolStripButton_Click(object sender, EventArgs e)
        {
            currentModule.Instance.Backward();
        }

        private void forwardToolStripButton_Click(object sender, EventArgs e)
        {
            currentModule.Instance.Forward();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            currentModule.Instance.New();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            currentModule.Instance.Open();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            currentModule.Instance.Save();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            currentModule.Instance.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            currentModule.Instance.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            currentModule.Instance.Paste();
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            currentModule.Instance.Print();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            currentModule.Instance.Help();
        }
        # endregion

        # region Toolstrip menu click handlers
        private void toolStripComboBoxModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadModule();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }
      
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        # endregion

        private void systemSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EISClientSettings settings = new EISClientSettings();
            settings.ShowDialog();
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EISUserManagement usrmgmnt = new EISUserManagement(this);
            usrmgmnt.ShowDialog();
        }
    }
}
