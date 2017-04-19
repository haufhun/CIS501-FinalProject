using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();

            using (eventLog1 = new EventLog("Application"))
            {
                eventLog1.Source = "Application";
                eventLog1.WriteEntry("Log message example", EventLogEntryType.Information, 101, 1);
            }
        }
    }
}
