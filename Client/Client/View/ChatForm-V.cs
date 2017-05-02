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
        //
        private ChatRoom _Chat;
        //
        private SendMessageHandler _sendMessageHandler;

        private readonly ChatDB _chatDb;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iChat"></param>
        /// <param name="sm"></param>
        /// <param name="chatDb"></param>
        public ChatForm(ChatRoom Chat, SendMessageHandler sm, ChatDB chatDb)
        {
            _Chat = Chat;
            _sendMessageHandler = sm;
            _chatDb = chatDb;



            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSend_Click(object sender, EventArgs e)
        {
            uxMessageTextBox.Text = "";
            _sendMessageHandler(uxMessageTextBox.Text, _Chat);
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
        }

        public void UpdateMessageView(string id)
        {
            var chatRoom = _chatDb.ChatRooms[id];

            Invoke(new MethodInvoker(uxMessageListBox.BeginUpdate));
            Invoke(new MethodInvoker(uxMessageListBox.Items.Clear));
            foreach (var m in chatRoom.MessageHistory)
            {
                    string[] iteminfo = {m.Sender +": " + m.Body};
                    var item = new ListViewItem(iteminfo);
                    Invoke(new MethodInvoker(delegate { uxMessageListBox.Items.Add(item); }));
            }
            Invoke(new MethodInvoker(uxMessageListBox.EndUpdate));
        }
    }
}
