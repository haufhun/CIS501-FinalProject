﻿using System;
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
        // Handler for adding contact to a chat room
        private AddContactToRoomHandler _addCToRoomHandler;
        // Handler for closing a chat room
        private CloseRoomHandler _closeRoomHandler;
        // Variable to read the Chat Database
        private readonly ChatDB _chatDb;

        /// <summary>
        /// This method initializes the Chat form
        /// </summary>
        /// <param name="Chat">Chatroom object passed in</param>
        /// <param name="sm">Handler to send message passed in</param>
        /// <param name="addCToRoomHandler">Handler to add contact to room</param>
        /// <param name="closeRoomHandler">Handler to close a chat room</param>
        /// <param name="chatDb">Database for Chat to be passed in and read</param>
        public ChatForm(ChatRoom Chat, SendMessageHandler sm, AddContactToRoomHandler addCToRoomHandler, CloseRoomHandler closeRoomHandler, ChatDB chatDb)
        {
            _chatRoom = Chat;
            _sendMessageHandler = sm;
            _addCToRoomHandler = addCToRoomHandler;
            _closeRoomHandler = closeRoomHandler;
            _chatDb = chatDb;



            InitializeComponent();
        }

        /// <summary>
        /// maybe dont need
        /// </summary>
        public ChatRoom ChatRoom
        {
            get { return _chatRoom; }
            set { _chatRoom = value; }
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
        /// <summary>
        /// Handler for add contact button press
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAddContact_Click(object sender, EventArgs e)
        {
            if (uxListView.SelectedItems.Count > 0)
                _addCToRoomHandler(_chatRoom, uxListView.SelectedItems[0].SubItems[0].Text);
            else
                MessageBox.Show("Please select a contact to add to the chat room!");
           
        }
        /// <summary>
        /// Handler for end chat button press
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxEndChat_Click(object sender, EventArgs e)
        {
            _closeRoomHandler(_chatRoom);
        }
        /// <summary>
        /// This method updates the Contact View 
        /// </summary>
        /// <param name="id">Chatroom id</param>
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
        /// <param name="id">Chatroom id</param>
        public void UpdateMessageView(string id)
        {
            var chatRoom = _chatDb.ChatRooms[id];

            Invoke(new MethodInvoker(uxMessageListBox.BeginUpdate));
            Invoke(new MethodInvoker(uxMessageListBox.Items.Clear));
            foreach (var m in chatRoom.MessageHistory)
            {
                //if (DateTime.Now.ToShortTimeString() != m.Time.ToShortTimeString())
                //{
                //    var dateItem = new ListViewItem("\t\t" + m.Time.ToShortTimeString());
                //    Invoke(new MethodInvoker(delegate { uxMessageListBox.Items.Add(dateItem.Text); }));
                //}
                    string[] itemInfo = { m.Time.ToShortTimeString()+ "\t" +m.Sender.Username +": " + m.Body };
                    var item = new ListViewItem(itemInfo);
                    Invoke(new MethodInvoker(delegate { uxMessageListBox.Items.Add(item.Text); }));
            }
            Invoke(new MethodInvoker(uxMessageListBox.EndUpdate));
        }


    }
}
