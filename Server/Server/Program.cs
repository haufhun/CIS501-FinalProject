using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server.Controller;
using Server.Model;
using Server.View;
using WebSocketSharp;
using WebSocketSharp.Server;
using Chat_CSLibrary;

namespace Server
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var db = new ChatDb();
            var c = new ServerController(db);
            var sf = new ServerForm(c.ChatDelegate);

            c.RegisterEventLog(sf.SendEvent);

            Application.Run(sf);
        }
    }
}
