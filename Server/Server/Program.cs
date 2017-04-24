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
        //The delegate that will update the GUI application with information from the server
        public delegate void Observer();
        //The delegate that will handle a user interaction
        public delegate void InputHandler(IMensaje mensaje);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var db = new ChatDb();
            var c = new ServerController(db);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ServerForm());
        }
    }
}
