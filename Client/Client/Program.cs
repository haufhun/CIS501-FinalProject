using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chat_CSLibrary;
using Client.Controller;
using Client.Model;
using Client.View;

namespace Client
{
    public delegate bool Message(string message);
    //defines the type of method that handles HomeForm Events
    public delegate void HomeFormObserver();
    //defines the type of method that handles ChatForm Events
    public delegate void ChatFormObserver(IChatRoom chatRoom);
    //defines the type of method that handles SignInFormEvents
    public delegate void SignInFormObserver();

    // defines the type of method that handles a log in event
    public delegate void SignInHandler(string name, string password);
    // defines the type of method that handles a log out event
    public delegate void SignOutHandler();
    // defines the type of method that handles an add contact event
    public delegate void AddContactHandler(string name);
    // defines the type of method that handles a remove contact event
    public delegate void RemoveContactHandler(string name);
    // defines the type of method that handles an add contact to room event
    public delegate void AddContactToRoomHandler(IChatRoom chatRoom, string name);
    // defines the type of method that handles a create chat room event
    public delegate void CreateRoomHandler(string name);

    public delegate void SendMessageHandler(string message, IChatRoom chatRoom);

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
            var chatDB = new ChatDB();
            var c = new ClientController_C(chatDB);
            var aCForm = new AddContactForm();
            var hForm = new HomeForm(c.SignIn, c.SignOut, c.AddContact, c.RemoveContact, c.AddContactToRoom,c.CreateChatRoom, c.SendMessage,aCForm);
            var sIForm = new SignInForm(c.SignIn, hForm);

            c.MessageReceived += c.message;


            c.HomeFormRegister(hForm.UpdateView);
            c.HomeFormRegister(hForm.SignOut);

            c.ChatFormRegister(hForm.StartChat);

            c.SignInRegister(sIForm.EventSuccessfulLogin);
            c.SignInRegister(sIForm.EventUnSuccessfulLogin);
            c.SignInRegister(sIForm.SignOut);


            hForm.Show();
            hForm.Visible = false;

            aCForm.Show();
            aCForm.Visible = false;

            Application.Run(sIForm);


        }
    }
}
