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

namespace Client
{
    public partial class ChatForm : Form
    {

        private IChatRoom _iChat;
        private SendMessageHandler _sendMessageHandler;

        public ChatForm(IChatRoom iChat , SendMessageHandler sm)
        {
            _iChat = iChat;
            _sendMessageHandler = sm;


            InitializeComponent();
        }

        private void uxSend_Click(object sender, EventArgs e)
        {
            _sendMessageHandler(uxMessageTextBox.Text, _iChat);
        }
    }
}
