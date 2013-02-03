using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EISModuleComponents;
namespace Subscribo
{
    public class SubscriboModule:EISModule
    {
        ModuleUI moduleUI;
        EISModuleHost hostModule;
        string name, version, description, author;


        public SubscriboModule()
        {
            moduleUI = new ModuleUI();
        }
        
        # region EISModule members
        public EISModuleHost HostModule
        {
            get
            {
                return hostModule;
            }
            set
            {
                hostModule = value;
            }
        }

        public string ModuleName
        {
            get { return name; }
        }

        public string Version
        {
            get { return version; }
        }

        public string Description
        {
            get { return description; }
        }

        public string Author
        {
            get { return author; }
        }

        public System.Windows.Forms.UserControl MainInterface
        {
            get { return moduleUI; }
        }

        public void InitializeModule()
        {
            name = "Orders";
            version     = "0.0.1";
            description = "Module for handling of orders";
            author      = "Peter Adamondy";
        }

        public void DisposeModule()
        {
           // todo
        }

        public void ShowSettings()
        {
           // todo
        }

        public void StopWork()
        {
            // todo
        }


        public void Forward()
        {
            // todo
        }

        public void Backward()
        {
            // todo
        }

        public void New()
        {
            // todo
        }

        public void Open()
        {
            // todo
        }

        public void Save()
        {
            // todo
        }

        public void Print()
        {
            // todo
        }

        public void Cut()
        {
            // todo
        }

        public void Copy()
        {
            // todo
        }

        public void Paste()
        {
            // todo
        }

        public void Help()
        {
            // todo
        }
        # endregion




    }
}
