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
    public partial class EISUserManagement : Form
    {
        private EISModuleHost host;
        
        public EISUserManagement(EISModuleHost Host)
        {
            InitializeComponent();

            host = Host;
        }
    }
}
