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
        private  AddContactForm _aCForm;

        public HomeForm(SignInHandler sI, SignOutHandler sO, AddContactHandler ac, RemoveContactHandler rc, AddContactToRoomHandler acr, CreateRoomHandler cr, SendMessageHandler sm, AddContactForm aCForm)
        {
            _sInHandler = sI;
            _sOutHandler = sO;
            _addCHandler = ac;
            _removeCHandler = rc;
            _addCToRoomHandler = acr;
            _createRoomHandler = cr;
            _sendMessageHandler = sm;
            _aCForm = aCForm;

            InitializeComponent();
        }

        private void uxSignOut_Click(object sender, System.EventArgs e)
        {
            _sOutHandler();
        }

        public void SignOut()
        {
            this.Invoke(new MethodInvoker(this.Hide));
        }

        private void uxStartChat_Click(object sender, System.EventArgs e)
        {
            _createRoomHandler("username");// pass in username from list view
        }

        public void StartChat(IChatRoom iChat)
        {
            var c = new ChatForm(iChat, _sendMessageHandler);
            c.Invoke(new MethodInvoker(c.Show));

        }

        private void uxAddContact_Click(object sender, System.EventArgs e)
        {
            //var addCForm = new AddContactForm();

            _aCForm.Invoke(new MethodInvoker(_aCForm.Show));

            // not working for some reason...
            _addCHandler("tyler");
            /*if (_aCForm.DialogResult == DialogResult.OK)
            {
               _addCHandler(_aCForm.uxInfoTxt.Text);
            }*/

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
