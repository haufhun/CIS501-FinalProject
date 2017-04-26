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
        private InputHandler _handle;

        private ChatDb _db;

        private List<Button> _testingButtons;

        private List<TextBox> _testingTextBoxes;

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

            _testingButtons = new List<Button>
            {
                uxLoginButton,
                uxAddCnctBtn,
                uxRmvCnctBtn,
                uxCreateChatRoomBtn
            };

            _testingTextBoxes = new List<TextBox>
            {
                uxContactTB,
                uxPasswordTB,
                uxUsernameTB
            };

            toolStripComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox1.SelectedIndex = 0;
        }

        public void SendEvent(IMensaje m)
        {
            var lt = new ListViewItem(((Mensaje)m).ToArrayString());
            listView1.Items.Add(lt);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var m = new Mensaje(new User(new Contact(uxUsernameTB.Text, Status.Online), uxPasswordTB.Text, "1234"), false);

            _handle(m, "1234");
            uxUsernameTB.Clear();
            uxPasswordTB.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var m = new Mensaje(State.RemoveContact, new Contact(uxContactTB.Text, Status.Online), new User(new Contact(uxUsernameTB.Text, Status.Online), null, "1234"));

            _handle(m, "1234");
            uxContactTB.Clear();
            uxUsernameTB.Clear();
        }

        private void uxAddCnctBtn_Click(object sender, EventArgs e)
        {
            var m = new Mensaje(State.AddContact, new Contact(uxContactTB.Text, Status.Online), new User(new Contact(uxUsernameTB.Text, Status.Online), null, "1234"));

            _handle(m, "1234");
            uxContactTB.Clear();
            uxUsernameTB.Clear();
        }

        private void uxCreateChatRoomBtn_Click(object sender, EventArgs e)
        {
            var m = new Mensaje(new ChatRoom(new User(new Contact(uxUsernameTB.Text, Status.Online), ))

        }

        public void UpdateUserListView()
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

        private void UpdateUserWebBrowser(IEnumerable<string> s)
        {
            var userList = "";

            foreach(var un in s)
            {
                var u = _db.LookupUser(un);

                userList +=
                    "<li><h2>" + u.ContactInfo.Username + "</h2></li>" +
                    "<ul>" + "" +
                    "<li>Password: " + u.Password + "</li>" +
                    "<li>Status: " + u.ContactInfo.OnlineStatus.ToString() + "</li>" +
                    "<li><h3>ContactList:</h3></li>" + 
                    "<ul>";

                foreach(var c in u.ContactList.Contacts)
                {
                    userList += "<li>" + c.Username + " (<em>" + c.OnlineStatus.ToString() + "</em>)</li>";
                }

                userList += "</ul></ul>";
            }

            uxWebBrowser.DocumentText = 
                "<html>" + 
                "<head><style>li { list-style-type: square; }</style></head>" +
                "<body>" +
                "<h1>Users:</h1><ul>" +
                userList + 
                "</details></ul></body>" + 
                "</html>";
        }

        private void TestHtmlWriter(IEnumerable<string> s)
        {
            var stringWriter = new StringWriter();
            using (var writer = new HtmlTextWriter(stringWriter))
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Head);
                    writer.RenderBeginTag(HtmlTextWriterTag.Style);
                        writer.AddStyleAttribute(HtmlTextWriterStyle.ListStyleType, "square");
                    writer.RenderEndTag(); //for style
                writer.RenderEndTag(); //for head

            }
        }

        private void uxUsersListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lv = (ListView)sender;
            var s = new List<string>();

            foreach (ListViewItem lvi in lv.SelectedItems)
            {
                s.Add(lvi.Text);
            }

            UpdateUserWebBrowser(s);
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = ((ToolStripComboBox)sender).SelectedIndex;

            foreach (var u in _testingButtons) u.Enabled =  index == 1;
            foreach (var u in _testingTextBoxes) u.Enabled = index == 1;
        }

    }
}
