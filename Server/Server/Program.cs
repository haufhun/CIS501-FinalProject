using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server.Controller;
using Server.View;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Server
{
    static class Program
    {
        //The delegate that will update the GUI application with information from the server
        public delegate void Observer();
        //The delegate that will handle a user interaction
        public delegate void InputHandler();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var wss = new WebSocketServer(8001);

            // Add the Chat websocket service
            wss.AddWebSocketService<Chat>("/chat");

            // Start the server
            wss.Start();

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();

            // Stop the server
            wss.Stop();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ServerForm());
        }
    }
}
