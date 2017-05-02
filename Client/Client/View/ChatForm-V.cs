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
        private IChatRoom _iChat;
        //
        private SendMessageHandler _sendMessageHandler;
        private readonly ChatDB _chatDb;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iChat"></param>
        /// <param name="sm"></param>
        /// <param name="chatDb"></param>
        public ChatForm(IChatRoom iChat, SendMessageHandler sm, ChatDB chatDb)
        {
            _iChat = iChat;
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
            _sendMessageHandler(uxMessageTextBox.Text, _iChat);
        }

        public void UpdateView(string id)
        {
            Invoke(new MethodInvoker(uxListView.BeginUpdate));
            Invoke(new MethodInvoker(uxListView.Items.Clear));
            var chatRoom = _chatDb.ChatRooms[id];
            foreach (var c in chatRoom.ContactsToAdd.Contacts)
            {
                    string[] iteminfo = { c.Username, c.OnlineStatus.ToString()};
                    var item = new ListViewItem(iteminfo);
                    Invoke(new MethodInvoker(delegate { uxListView.Items.Add(item); }));             
            }
            Invoke(new MethodInvoker(uxListView.EndUpdate));

            Invoke(new MethodInvoker(uxMessageListBox.BeginUpdate));
            Invoke(new MethodInvoker(uxMessageListBox.Items.Clear));
            foreach (var c in _chatDb.ChatRooms)
            {
                if (c.Key == id)
                {
                    string[] iteminfo = {c.Value.MessageHistory.ToString()};
                    var item = new ListViewItem(iteminfo);
                    Invoke(new MethodInvoker(delegate { uxMessageListBox.Items.Add(item); }));
                }
            }
            Invoke(new MethodInvoker(uxMessageListBox.EndUpdate));
        }
    }
}
