using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EISModuleComponents
{
    public interface EISModule
    {
        EISModuleHost HostModule { get; set; }
        string ModuleName { get; }
        string Version { get; }
        string Description { get; }
        string Author { get; }

        System.Windows.Forms.UserControl MainInterface { get; }

        void InitializeModule();
        void DisposeModule();
        void ShowSettings();
        void StopWork();

        void Forward();
        void Backward();
        void New();
        void Open();
        void Save();
        void Print();
        void Cut();
        void Copy();
        void Paste();
        void Help();

    }

    public interface EISModuleHost
    {
        GlobalServices Services { get; }
        
        void Notify(string ErrorMessage, EISErrorTypes ErrorType);
        void SetStatus(string status);
        void WriteToLog(string message);
        System.Windows.Forms.ToolStripProgressBar Progressbar { get; }
        
    }

    public enum EISErrorTypes
    {
        Warning,
        Error,
        Information,
        Message
    }

}
