using System;
using System.Windows.Forms;
using Server.Controller;
using Server.Model;
using Server.View;

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
            var sf = new ServerForm(db, c.ChatDelegate);

            //EventLogObservers
            c.Register(sf.SendEvent);

            //Observers
            c.Register(sf.UpdateUserListView);
            c.Register(sf.UpdateUserWebBrowser);
            c.Register(sf.UpdateChatRoomWebBrowser);

            Application.Run(sf);
        }
    }
}
