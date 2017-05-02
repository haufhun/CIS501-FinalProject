using System;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sI"></param>
        /// <param name="sO"></param>
        /// <param name="ac"></param>
        /// <param name="rc"></param>
        /// <param name="acr"></param>
        /// <param name="cr"></param>
        /// <param name="sm"></param>
        /// <param name="chatDb"></param>
        /// <param name="aCForm"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSignOut_Click(object sender, System.EventArgs e)
        {
            _sOutHandler();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxStartChat_Click(object sender, System.EventArgs e)
        {
            if (uxListView.SelectedItems.Count > 0)
                _createRoomHandler(uxListView.SelectedItems[0].SubItems[0].Text);
            else
                MessageBox.Show("Please select a contact to chat with!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAddContact_Click(object sender, System.EventArgs e)
        {
            _aCForm.ShowDialog();

            if (_aCForm.DialogResult == DialogResult.OK)
            {
                _addCHandler(_aCForm.uxTxt.Text);
            }
            else
            {
                _aCForm.Hide();            
            }
            _aCForm.uxTxt.Text = "";

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxDeleteContact_Click(object sender, System.EventArgs e)
        {
            if (uxListView.SelectedItems.Count > 0)
                _removeCHandler(uxListView.SelectedItems[0].SubItems[0].Text);
            else
                MessageBox.Show("Please select a contact to remove!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iChat"></param>
        public void StartChat(IChatRoom iChat)
        {
            var c = new ChatForm(iChat, _sendMessageHandler, _chatDb);
            c.Show();
            //c.Invoke(new MethodInvoker(c.Show));

        }

        /// <summary>
        /// 
        /// </summary>
        public void AddContact()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public void RemoveContact()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        public void SignOut()
        {
            this.Invoke(new MethodInvoker(this.Hide));
        }

        public void PrintErrorMessage(string message)
        {
            MessageBox.Show(message);
        }
        /// <summary>
        /// 
        /// </summary>
        public void UpdateView()
        {
            
            Invoke(new MethodInvoker( uxListView.BeginUpdate));
            Invoke(new MethodInvoker(uxListView.Items.Clear));
            foreach (var c in _chatDb.User.ContactList.Contacts)
            {
                string[] iteminfo = { c.Username, c.OnlineStatus.ToString() };
                var item = new ListViewItem(iteminfo);
                Invoke(new MethodInvoker(delegate { uxListView.Items.Add(item); }));
            }
            Invoke(new MethodInvoker(uxListView.EndUpdate));
        }


    }
}
