using System.Windows.Forms;
using Chat_CSLibrary;
using Client.Model;

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
        private ChatDB _chatDb;
        private AddContactForm _aCForm;

        public HomeForm(SignInHandler sI, SignOutHandler sO, AddContactHandler ac, RemoveContactHandler rc, AddContactToRoomHandler acr, CreateRoomHandler cr, SendMessageHandler sm, ChatDB chatDb, AddContactForm aCForm)
        {
            _sInHandler = sI;
            _sOutHandler = sO;
            _addCHandler = ac;
            _removeCHandler = rc;
            _addCToRoomHandler = acr;
            _createRoomHandler = cr;
            _sendMessageHandler = sm;
            _chatDb = chatDb;
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
            _aCForm.ShowDialog();

            if (_aCForm.DialogResult == DialogResult.OK)
            {
               _addCHandler(_aCForm.uxTxt.Text);
            }

        }
        public void AddContact()
        {
            uxListView.BeginUpdate();

            uxListView.EndUpdate();
            //populate list view from user
        }
        private void uxDeleteContact_Click(object sender, System.EventArgs e)
        {
            
            //look for contact selected in list view..
            if (uxListView.SelectedItems.Count > 0)
                _removeCHandler(uxListView.SelectedItems[0].SubItems[0].ToString());
            else
                MessageBox.Show("Please select a contact to remove!");
        }   
        public void removeContact()
        {
            uxListView.BeginUpdate();
            var item = new ListViewItem();
                //populate list view from user
           // _chatDb.User;
            uxListView.EndUpdate();
        }
        public void UpdateView()
        {
            throw new System.NotImplementedException();
        }
    }
}
