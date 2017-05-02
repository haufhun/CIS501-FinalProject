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
            string folder = System.IO.Path.GetFullPath(@"..\..\") + "Lib";
            System.IO.Directory.CreateDirectory(folder);
            string path = System.IO.Path.Combine(folder, "UserFile.txt");

            var db = LoadUsers(path) ?? new ChatDb();
            var c = new ServerController(db);
            var sf = new ServerForm(db, c.ChatDelegate);

            //EventLogObservers
            c.Register(sf.SendEvent);

            //Observers
            c.Register(sf.UpdateUserListView);
            c.Register(sf.UpdateUserWebBrowser);
            c.Register(sf.UpdateChatRoomWebBrowser);

            Application.Run(sf);
            MessageBox.Show(path);
            c.StoreUsers(path);
        }

        private static ChatDb LoadUsers(string path)
        {
            if (System.IO.File.Exists(path))
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(path))
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
