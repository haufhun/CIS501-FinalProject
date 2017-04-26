using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Controller;
using Client.View;

namespace Client
{
    public delegate bool Message(string message);
    //defines the type of method that handles HomeForm Events
    public delegate void HomeFormObserver();
    //defines the type of method that handles ChatForm Events
    public delegate void ChatFormObserver();
    //defines the type of method that handles SignInFormEvents
    public delegate void SignInFormObserver();

    // defines the type of method that handles a log in event
    public delegate void SignInHandler(string name, string password);
    // defines the type of method that handles an add contact event
    public delegate void AddContactHandler(string name);
    // defines the type of method that handles a remove contact event
    public delegate void RemoveContactHandler(string name);
    // defines the type of method that handles an add contact to room event
    public delegate void AddContactToRoomHandler(string name);
    // defines the type of method that handles a create chat room event
    public delegate void CreateRoomHandler();

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

            ClientController_C c = new ClientController_C("tyler");

            HomeForm hForm = new HomeForm(c.SignIn, c.AddContact, c.RemoveContact, c.AddContactToRoom,c.CreateRoom);
           
            SignInForm sIForm = new SignInForm(c.SignIn, hForm);

            c.MessageReceived += c.message;

            c.HomeFormRegister(hForm.Update);
            c.SignInRegister(sIForm.EventSuccessfulLogin);
           // sIForm.Show();
            hForm.Show();
            Application.Run(sIForm);
          //  Application.Run(hForm);

            //Application.Run(new ChatForm());

        }
    }
}
