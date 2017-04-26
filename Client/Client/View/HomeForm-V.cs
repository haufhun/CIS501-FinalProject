using System.Windows.Forms;
using Chat_CSLibrary;

namespace Client.View
{
    public partial class HomeForm : Form
    {
        private SignInHandler _sInHandler;
        private SignOutHandler _sOutHandler;
        private AddContactHandler _addCHandler;
        private RemoveContactHandler _removeCHandler;
        private AddContactToRoomHandler _addCToRoomHandler;
        private CreateRoomHandler _createRoomHandler;

        public HomeForm(SignInHandler sI, SignOutHandler sO, AddContactHandler ac, RemoveContactHandler rc, AddContactToRoomHandler acr, CreateRoomHandler cr)
        {
            _sInHandler = sI;
            _sOutHandler = sO;
            _addCHandler = ac;
            _removeCHandler = rc;
            _addCToRoomHandler = acr;
            _createRoomHandler = cr;

            InitializeComponent();
        }

        private void uxSignOut_Click(object sender, System.EventArgs e)
        {
            _sOutHandler();
        }

        public void SignOut()
        {
            Hide();
        }

        private void uxStartChat_Click(object sender, System.EventArgs e)
        {
            _createRoomHandler();
        }
        public void StartChat(IChatRoom iChat)
        {
            ChatForm c = new ChatForm(iChat);
            c.Invoke(new MethodInvoker(c.Show));

        }

        private void uxAddContact_Click(object sender, System.EventArgs e)
        {
            //_addCHandler(string name);
        }

        private void uxDeleteContact_Click(object sender, System.EventArgs e)
        {
           // _removeCHandler(string name);
        }

        public void UpdateView()
        {
            throw new System.NotImplementedException();
        }
    }
}
