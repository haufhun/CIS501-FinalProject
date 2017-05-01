using System;
using System.Windows.Forms;
using Server.Controller;
using Server.Model;
using Server.View;
using Newtonsoft.Json;

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

            var db = LoadUsers() ?? new ChatDb();
            var c = new ServerController(db);
            var sf = new ServerForm(db, c.ChatDelegate);

            //EventLogObservers
            c.Register(sf.SendEvent);

            //Observers
            c.Register(sf.UpdateUserListView);
            c.Register(sf.UpdateUserWebBrowser);
            c.Register(sf.UpdateChatRoomWebBrowser);

            Application.Run(sf);
            c.StoreUsers();
        }

        private static ChatDb LoadUsers()
        {
            if (System.IO.File.Exists("UserFile.txt"))
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader("UserFile.txt"))
                {
                    string s = file.ReadLine();
                    ChatDb c = JsonConvert.DeserializeObject<ChatDb>(s);
                    return c;
                }
            }
            else return null;

        }
    }
}
