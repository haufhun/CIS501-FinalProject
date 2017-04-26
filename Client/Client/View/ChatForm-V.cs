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

        public ChatForm(IChatRoom iChat)
        {
            _iChat = iChat;
            InitializeComponent();
        }

    }
}
