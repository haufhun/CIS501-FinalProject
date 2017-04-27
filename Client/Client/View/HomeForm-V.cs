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
        private SendMessageHandler _sendMessageHandler;

        public HomeForm(SignInHandler sI, SignOutHandler sO, AddContactHandler ac, RemoveContactHandler rc, AddContactToRoomHandler acr, CreateRoomHandler cr, SendMessageHandler sm)
        {
            _sInHandler = sI;
            _sOutHandler = sO;
            _addCHandler = ac;
            _removeCHandler = rc;
            _addCToRoomHandler = acr;
            _createRoomHandler = cr;
            _sendMessageHandler = sm;

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
            var c = new ChatForm(iChat, _sendMessageHandler);
            c.Invoke(new MethodInvoker(c.Show));

        }

        private void uxAddContact_Click(object sender, System.EventArgs e)
        {
            var addCForm = new AddContactForm();

            if (addCForm.ShowDialog(this) == DialogResult.OK)
            {
                _addCHandler(addCForm.uxInfoTxt.Text);
            }
        }

        private void uxDeleteContact_Click(object sender, System.EventArgs e)
        {
            //look for contact selected in list view.../ gridview?
           // _removeCHandler(string name);
        }

        public void UpdateView()
        {
            throw new System.NotImplementedException();
        }
    }
}
