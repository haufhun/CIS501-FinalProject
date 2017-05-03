using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chat_CSLibrary;
using Client.Model;

namespace Client
{
    public partial class ChatForm : Form
    {
        // Variable for accessing the chatroom
        private ChatRoom _chatRoom;
        // Handler for sending a message
        private SendMessageHandler _sendMessageHandler;
        private AddContactToRoomHandler _addCToRoomHandler;
        // Variable to read the Chat Database
        private readonly ChatDB _chatDb;

        /// <summary>
        /// This method initializes the Chat form
        /// </summary>
        /// <param name="Chat"></param>
        /// <param name="sm">Handler to send message passed in</param>
        /// <param name="addCToRoomHandler"></param>
        /// <param name="chatDb">Database for Chat to be passed in and read</param>
        /// <param name="iChat">Chatroom object passed in</param>
        public ChatForm(ChatRoom Chat, SendMessageHandler sm, AddContactToRoomHandler addCToRoomHandler, ChatDB chatDb)
        {
            _chatRoom = Chat;
            _sendMessageHandler = sm;
            _addCToRoomHandler = addCToRoomHandler;
            _chatDb = chatDb;



            InitializeComponent();
        }

        /// <summary>
        /// Method to handle the send button pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSend_Click(object sender, EventArgs e)
        {

            _sendMessageHandler(uxMessageTextBox.Text, _chatRoom, this);
            uxMessageTextBox.Text = "";
        }
        private void uxAddContact_Click(object sender, EventArgs e)
        {
            if (uxListView.SelectedItems.Count > 0)
                _addCToRoomHandler(_chatRoom, uxListView.SelectedItems[0].SubItems[0].Text);
            else
                MessageBox.Show("Please select a contact to add to the chat room!");
           
        }

        private void uxEndChat_Click(object sender, EventArgs e)
        {

        }

        public void UpdateContactView(string id)
        {
            var chatRoom = _chatDb.ChatRooms[id];

            Invoke(new MethodInvoker(uxListView.BeginUpdate));
            Invoke(new MethodInvoker(uxListView.Items.Clear));
            foreach (var c in chatRoom.ContactsToAdd.Contacts)
            {
                string[] iteminfo = {c.Username, c.OnlineStatus.ToString()};
                var item = new ListViewItem(iteminfo);
                Invoke(new MethodInvoker(delegate { uxListView.Items.Add(item); }));
            }
            Invoke(new MethodInvoker(uxListView.EndUpdate));

            var users = _chatDb.ChatRooms[id].Participants.Aggregate("ChatRoom -   ", (current, u) => current + ("{" + u.ContactInfo.Username + "}  "));
            this.Text = users;
        }
        /// <summary>
        /// This method will update the messages being viewed
        /// </summary>
        /// <param name="id"></param>
        public void UpdateMessageView(string id)
        {
            var chatRoom = _chatDb.ChatRooms[id];

            Invoke(new MethodInvoker(uxMessageListBox.BeginUpdate));
            Invoke(new MethodInvoker(uxMessageListBox.Items.Clear));
            foreach (var m in chatRoom.MessageHistory)
            {
                    string[] iteminfo = {m.Sender.Username +": " + m.Body};
                    var item = new ListViewItem(iteminfo);
                    Invoke(new MethodInvoker(delegate { uxMessageListBox.Items.Add(item.Text); }));
            }
            Invoke(new MethodInvoker(uxMessageListBox.EndUpdate));
        }


    }
}
