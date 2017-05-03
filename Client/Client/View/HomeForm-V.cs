using System;
using System.Windows.Forms;
using Chat_CSLibrary;
using Client.Model;

namespace Client.View
{
    public partial class HomeForm : Form
    {
        //Handler for sign in
        private SignInHandler _sInHandler;
        //Handler for sign out
        private SignOutHandler _sOutHandler;
        //Handler for add contact
        private AddContactHandler _addCHandler;
        //Handler for removing a contact
        private RemoveContactHandler _removeCHandler;
        //Handler to add contact to chat room
        private AddContactToRoomHandler _addCToRoomHandler;
        //Handler for creating a chat room
        private CreateRoomHandler _createRoomHandler;
        //Handler for closing a chat room
        private CloseRoomHandler _closeRoomHandler;
        //Handler for sending a message
        private SendMessageHandler _sendMessageHandler;
        //private field variable for chat database
        private ChatDB _chatDb;
        //private field for add contact form
        private AddContactForm _aCForm;

        /// <summary>
        /// This is where the homeform will be initialized
        /// </summary>
        /// <param name="sI">Sign in handler</param>
        /// <param name="sO">Sign out handler</param>
        /// <param name="ac">Add Contact handler</param>
        /// <param name="rc">Remove Contact handler</param>
        /// <param name="acr">Add Contact to Chatroom handler</param>
        /// <param name="cr">Create a chatroom handler</param>
        /// <param name="closeRoomHandler">Create a close chatroom handler</param>
        /// <param name="sm">Handler to send message</param>
        /// <param name="chatDb">Chat Database to be read</param>
        /// <param name="aCForm">Add Contact form to access</param>
        public HomeForm(SignInHandler sI, SignOutHandler sO, AddContactHandler ac, RemoveContactHandler rc,
            AddContactToRoomHandler acr, CreateRoomHandler cr, CloseRoomHandler closeRoomHandler, SendMessageHandler sm,
            ChatDB chatDb, AddContactForm aCForm)
        {
            _sInHandler = sI;
            _sOutHandler = sO;
            _addCHandler = ac;
            _removeCHandler = rc;
            _addCToRoomHandler = acr;
            _createRoomHandler = cr;
            _closeRoomHandler = closeRoomHandler;
            _sendMessageHandler = sm;
            _chatDb = chatDb;
            _aCForm = aCForm;

            InitializeComponent();

        }

        /// <summary>
        /// This handles the sign out button press
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSignOut_Click(object sender, System.EventArgs e)
        {
            _sOutHandler();
        }

        /// <summary>
        /// This handles the button press to start the chat
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
        /// This handles the button press for adding a contact
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
            _aCForm.uxTxt.Select();
        }

        /// <summary>
        /// This handles the button press for deleting a contact
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxDeleteContact_Click(object sender, System.EventArgs e)
        {
          
            if (uxListView.SelectedItems.Count > 0)
            {
                switch (MessageBox.Show(this, "Are you sure you want to delete '" + uxListView.SelectedItems[0].SubItems[0].Text + "' off your friends list?", "Confirm Removal", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        break;
                    case DialogResult.Yes:
                        _removeCHandler(uxListView.SelectedItems[0].SubItems[0].Text);
                        break;
                }
            }
            else
                MessageBox.Show("Please select a contact to remove!");
        }

        /// <summary>
        ///  This handles what to do with StartChat
        /// </summary>
        /// <param name="chatRoom">Chatroom to be passed</param>
        /// <param name="chatForm">Should be null when Calling StartChat</param>
        public void StartChat(ChatRoom chatRoom, ChatForm chatForm)
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                ChatForm cForm;
                if (!_chatDb.ChatForms.ContainsKey(chatRoom.Id))
                {
                    cForm = new ChatForm(chatRoom, _sendMessageHandler, _addCToRoomHandler, _closeRoomHandler, _chatDb);
                    _chatDb.ChatForms.Add(chatRoom.Id, cForm);
                }
                else cForm = _chatDb.ChatForms[chatRoom.Id];



                cForm.Show();
                cForm.UpdateContactView(chatRoom.Id);
                cForm.UpdateMessageView(chatRoom.Id);
            }));

        }

        /// <summary>
        /// This method handls sending text messages
        /// </summary>
        /// <param name="chatRoom">Object chatRoom being passed in</param>
        /// <param name="cForm">The chatForm to update the view on</param>
        public void SendTextMessage(ChatRoom chatRoom, ChatForm cForm)
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                cForm.UpdateContactView(chatRoom.Id);
                cForm.UpdateMessageView(chatRoom.Id);
            }));
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
        /// This method controls what happens in the View for sign out
        /// </summary>
        public void SignOut()
        {
            if (InvokeRequired)
                this.Invoke(new MethodInvoker(this.Hide));
            else
                this.Hide();
        }

        /// <summary>
        /// This prints out the error message on a message box
        /// </summary>
        /// <param name="message">The error message to be printed</param>
        public void PrintErrorMessage(string message)
        {
            MessageBox.Show(message);
        }

        /// <summary>
        /// This updates the View info
        /// </summary>
        public void UpdateView()
        {

            Invoke(new MethodInvoker(uxListView.BeginUpdate));
            Invoke(new MethodInvoker(uxListView.Items.Clear));
            foreach (var c in _chatDb.User.ContactList.Contacts)
            {
                string[] iteminfo = {c.Username, c.OnlineStatus.ToString()};
                var item = new ListViewItem(iteminfo);
                Invoke(new MethodInvoker(delegate { uxListView.Items.Add(item); }));
            }
            Invoke(new MethodInvoker(uxListView.EndUpdate));

            Invoke(new MethodInvoker(UpdateHeaderName));
        }

        /// <summary>
        /// This method updates the header name in the View
        /// </summary>
        private void UpdateHeaderName()
        {
            this.Text = "Home - " + _chatDb.User.ContactInfo.Username + "          Status: " +
                        _chatDb.User.ContactInfo.OnlineStatus;
        }

        /// <summary>
        /// This method handles what happens upon form closing
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure you want to sign out and exit?", "Confirm Sign Out", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                case DialogResult.Yes:
                    _sOutHandler();
                    e.Cancel = true;
                    break;
            }
        }

    }
}

