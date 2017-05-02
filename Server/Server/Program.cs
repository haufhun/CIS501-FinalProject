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
            string folder = Path.GetFullPath(@"..\..\") + "Lib";
            System.IO.Directory.CreateDirectory(folder);
            string path = Path.Combine(folder, "UserFile.txt");

            ChatDb db;
            DialogResult result = MessageBox.Show("Would you like to select a user file to load?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                OpenFileDialog o = new OpenFileDialog();
                while (o.ShowDialog() != DialogResult.OK)
                {
                    path = o.FileName;
                }
                db = LoadUsers(path) ?? new ChatDb();
            }
            else db = new ChatDb();

            db = LoadUsers(path) ?? new ChatDb();
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
            if (File.Exists(path))
            {
                using (StreamReader file = new StreamReader(path))
                {
                    string s = file.ReadLine();
                    var c = JsonConvert.DeserializeObject<ChatDb>(s);
                    return c;
                }
            }
            return null;

        }
    }
}
