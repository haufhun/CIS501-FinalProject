using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{

    //defines the type of method that handles HomeForm Events
    public delegate void HomeFormObserver();
    //defines the type of method that handles ChatForm Events
    public delegate void ChatFormObserver();
    //defines the type of method that handles SignInFormEvents
    public delegate void SignInFormObserver(bool sucessful);

    // defines the type of method that handles a log in event
    public delegate void SignInHandler(string name, string password);
    // defines the type of method that handles an add contact event
    public delegate void AddContactHandler(string name);
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
            ClientController_C c = new ClientController_C();

            HomeForm hForm = new HomeForm(c.SignIn, c.AddContact, c.AddContactToRoom,c.CreateRoom);
            SignInForm sIForm = new SignInForm(hForm);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(sIForm);

            c.HomeFormRegister(hForm.Update);

           // Application.Run(new ChatForm());
           // Application.Run(new HomeForm());
        }
    }
}
