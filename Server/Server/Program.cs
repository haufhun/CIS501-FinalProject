using System;
using System.Windows.Forms;
using Server.Controller;
using Server.Model;
using Server.View;
using Newtonsoft.Json;
using System.IO;
using System.Threading;

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

            var folder = Path.GetFullPath(@"..\..\") + "Lib";
            Directory.CreateDirectory(folder);
            var path = Path.Combine(folder, "UserFile.txt");

            ChatDb db;
            var result = MessageBox.Show("Would you like to select a user file to load?", "What is this", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                var o = new OpenFileDialog();
                o.InitialDirectory = folder;
                o.FileName = path;
               // o.RestoreDirectory = true;

                if (o.ShowDialog() == DialogResult.OK)
                {
                    db = LoadUsers(o.FileName) ?? new ChatDb();
                }
                else
                {
                    db = new ChatDb();
                }
            }
            else
            {
                db = new ChatDb();
            }

            var c = new ServerController(db);
            var sf = new ServerForm(db, c.ChatDelegate);

            //EventLogObservers
            c.Register(sf.SendEvent);

            //Observers
            c.Register(sf.UpdateUserListView);
            c.Register(sf.UpdateUserWebBrowser);
            c.Register(sf.UpdateChatRoomWebBrowser);

            Application.Run(sf);

            var thread = new Thread(
                () =>
                {
                    MessageBox.Show("Closing the server, this may take a second. Click okay to close...");
                });
            thread.Start();

            c.StoreUsers(path);
        }

        private static ChatDb LoadUsers(string path)
        {
            if (!File.Exists(path)) return null;

            using (var file = new StreamReader(path))
            {
                var s = file.ReadLine();
                if (s == null) return null;

                var c = JsonConvert.DeserializeObject<ChatDb>(s);
                return c;
            }
        }
    }
}
