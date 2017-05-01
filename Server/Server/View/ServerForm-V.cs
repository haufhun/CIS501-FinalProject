using System;
using System.Windows.Forms;
using Server.Model;
using Chat_CSLibrary;
using static Server.Delegates;
using System.Collections.Generic;
using System.Web.UI;
using System.IO;

namespace Server.View
{
    public partial class ServerForm : Form
    {
        private readonly InputHandler _handle;

        private readonly ChatDb _db;

        private readonly List<Button> _testingButtons;

        private readonly List<TextBox> _testingTextBoxes;

        private List<string> _userLVSelected;

        public ServerForm(ChatDb db, InputHandler h)
        {
            _handle = h;
            _db = db;

            InitializeComponent();
            UpdateUserListView();

            listView1.Columns.Add("Time");
            listView1.Columns.Add("User");
            listView1.Columns.Add("Session Id");
            listView1.Columns.Add("State");
            listView1.Columns.Add("New User?");
            listView1.Columns.Add("Error?");
            listView1.Columns.Add("Error Message");
            listView1.Columns.Add("Chat Room Id");

            uxChatRoomListView.Columns.Add("Id");
            uxChatRoomListView.Columns.Add("Users");

            _testingButtons = new List<Button>
            {
                uxLoginButton,
                uxAddCnctBtn,
                uxRmvCnctBtn,
                uxCreateChatRoomBtn,
                uxLogoutButton,
                uxSendMessageBtn
            };

            _testingTextBoxes = new List<TextBox>
            {
                uxContactTB,
                uxPasswordTB,
                uxUsernameTB, 
                uxMessageTB,
                uxChatRoomIdTB
            };
            _userLVSelected = new List<string>();

            toolStripComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox1.SelectedIndex = 0;

            UpdateChatRoomWebBrowser();
        }

        private void uxLoginButton_Click(object sender, EventArgs e)
        {
            var m = new Mensaje(new User(new Contact(uxUsernameTB.Text, Status.Online), uxPasswordTB.Text, "1234"), false);

            _handle(m, "1234");
            foreach (var tb in _testingTextBoxes) tb.Clear();
        }
        private void uxAddCnctBtn_Click(object sender, EventArgs e)
        {
            var m = new Mensaje(State.AddContact, new Contact(uxContactTB.Text, Status.Online), new User(new Contact(uxUsernameTB.Text, Status.Online), null, "1234"));

            _handle(m, "1234");
            foreach (var tb in _testingTextBoxes) tb.Clear();
        }

        private void uxRmvCnctBtn_Click(object sender, EventArgs e)
        {
            var m = new Mensaje(State.RemoveContact, new Contact(uxContactTB.Text, Status.Online), new User(new Contact(uxUsernameTB.Text, Status.Online), null, "1234"));

            _handle(m, "1234");
            foreach (var tb in _testingTextBoxes) tb.Clear();
        }

        private void uxCreateChatRoomBtn_Click(object sender, EventArgs e)
        {
            var u1 = new User(new Contact(uxUsernameTB.Text, Status.Online), null, null);
            var u2 = new User(new Contact(uxContactTB.Text, Status.Online), null, null);

            var m = new Mensaje(new ChatRoom(null, u1, u2), u1);

            _handle(m, "1234");
            foreach (var tb in _testingTextBoxes) tb.Clear();
        }

        private void uxSendMessageBtn_Click(object sender, EventArgs e)
        {
            var m = new Mensaje(new ChatRoom(uxChatRoomIdTB.Text), new TextMessage(uxMessageTB.Text, new Contact(uxUsernameTB.Text, Status.Online)));
            _handle(m, "1234");
            foreach (var tb in _testingTextBoxes) tb.Clear();

        }
        private void uxLogoutButton_Click(object sender, EventArgs e)
        {
            var m = new Mensaje(State.Logout, new User(new Contact(uxUsernameTB.Text, Status.Offline), null, "1234"));
            _handle(m, "1234");
            foreach (var tb in _testingTextBoxes) tb.Clear();
        }

        public void SendEvent(IMensaje m)
        {
            var lt = new ListViewItem(((Mensaje)m).ToArrayString());

            if (uxUsersListView.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate { listView1.Items.Add(lt); }));
            }
            else
            {
                listView1.Items.Add(lt);
            }
        }

        public void UpdateUserListView()
        {
            if (uxUsersListView.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate { uxUsersListView.BeginUpdate(); }));
                Invoke(new MethodInvoker(delegate { uxUsersListView.Clear(); }));

                foreach (var u in _db.Users)
                {
                    string[] s = { u.ContactInfo.Username };
                    var li = new ListViewItem(s);
                    Invoke(new MethodInvoker(delegate { uxUsersListView.Items.Add(li); }));
                }
                Invoke(new MethodInvoker(delegate { uxUsersListView.EndUpdate(); }));
            }
            else
            {
                uxUsersListView.BeginUpdate();
                uxUsersListView.Clear();
                foreach (var u in _db.Users)
                {
                    string[] s = { u.ContactInfo.Username };
                    var li = new ListViewItem(s);
                    uxUsersListView.Items.Add(li);
                }
                uxUsersListView.EndUpdate();
            }
        }

        public void UpdateUserWebBrowser()
        {
            var userList = string.Empty;

            foreach(var un in _userLVSelected)
            {
                var u = _db.LookupUser(un);

                userList +=
                    "<li>" + u.ContactInfo.Username + "</li>" +
                    "<ul>" +
                    "<li>Password: " + u.Password + "</li>" +
                    "<li>Status: " + u.ContactInfo.OnlineStatus.ToString() + "</li>" +
                    "<li>ContactList:</li>" + 
                       "<ul>";

                foreach(var c in u.ContactList.Contacts)
                {
                    userList += "<li>" + c.Username + " (<em>" + c.OnlineStatus + "</em>)</li>";
                }

                userList += "</ul></ul>";
            }

            uxUsersWebBrowser.DocumentText =
                "<html>" +
                "<head>" + 
                    "<style>li { list-style-type: square; }</style>" + 
                "</head>" +
                "<body>" +
                    "<ul>" +
                        userList +
                    "</ul>" + 
                "</body>" +
                "</html>";
        }

        public void UpdateChatRoomWebBrowser()
        {
            var chatList = "";

            foreach(var cr in _db.ChatRooms)
            {
                var id = cr.Id;
                chatList += "<li>" + id + "</li><ul>" +
                            "<li>Participants</li>" + 
                                    "<ul>";
                
                foreach (var u in cr.Participants)
                {
                    chatList += "<li>" + u.ContactInfo.Username + " (<em>" + u.ContactInfo.OnlineStatus + "</em>)</li>";
                }
                chatList += "</ul>" +
                            "<li>ContactList:</li>" +
                            "<ul>";

                foreach (var c in cr.ContactsToAdd.Contacts)
                {
                    chatList += "<li>" + c.Username + " (<em>" + c.OnlineStatus + "</em>)</li>";
                }

                chatList += "</ul>" +
                            "<li>Messages:</li>" +
                                "<ul>";

                foreach(var m in cr.MessageHistory)
                {
                    //Does the ToString automatically!
                    chatList += "<li>" + m + "</li>";
                }

                chatList += "</ul></ul>";
            }

            uxChatMsgsWebBrowser.DocumentText =
                "<html>" +
                "<head><style>li { list-style-type: square; }</style></head>" +
                "<body>" +
                "<div>ChatRooms:</div>" +
                "<ul>" +
                    chatList +
                "</ul></body>" +
                "</html>";
        }

        private void uxUsersListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lv = (ListView)sender;
            _userLVSelected.Clear();

            foreach (ListViewItem lvi in lv.SelectedItems)
            {
                _userLVSelected.Add(lvi.Text);
            }

            UpdateUserWebBrowser();
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = ((ToolStripComboBox)sender).SelectedIndex;

            foreach (var u in _testingButtons) u.Enabled =  index == 1;
            foreach (var u in _testingTextBoxes) u.Enabled = index == 1;
        }
    }
}
