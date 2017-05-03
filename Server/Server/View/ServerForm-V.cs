using System;
using System.Windows.Forms;
using Server.Model;
using Chat_CSLibrary;
using static Server.Delegates;
using System.Collections.Generic;

namespace Server.View
{
    /// <summary>
    /// The Server Form class.
    /// </summary>
    public partial class ServerForm : Form
    {
        /// <summary>
        /// Private field to the delegate to the Controller
        /// </summary>
        private readonly InputHandler _handle;

        /// <summary>
        /// The instance of the chat database to update the database page.
        /// </summary>
        private readonly ChatDb _db;

        /// <summary>
        /// List of all buttons that can be used as an input to test.
        /// </summary>
        private readonly List<Button> _testingButtons;

        /// <summary>
        /// List of all text boxes on the testing tab.
        /// </summary>
        private readonly List<TextBox> _testingTextBoxes;

        /// <summary>
        /// List of the last selected users in the User list view.
        /// </summary>
        private List<string> _userLVSelected;

        /// <summary>
        /// Constructor that creates all the columns for the event log, initializes the list of buttons
        /// and text boxes for the testing page, and calls the update functions for user list view and the chat web browser.
        /// </summary>
        /// <param name="db">The chat database object.</param>
        /// <param name="h">The delegate from the controller to handle input from the server GUI.</param>
        public ServerForm(ChatDb db, InputHandler h)
        {
            _handle = h;
            _db = db;

            InitializeComponent();
            UpdateUserListView();

            uxEventLogListView.Columns.Add("Time");
            uxEventLogListView.Columns.Add("User");
            uxEventLogListView.Columns.Add("Session Id");
            uxEventLogListView.Columns.Add("State");
            uxEventLogListView.Columns.Add("New User?");
            uxEventLogListView.Columns.Add("Error?");
            uxEventLogListView.Columns.Add("Error Message");
            uxEventLogListView.Columns.Add("Chat Room Id");
            uxEventLogListView.Columns.Add("Send/Receive");

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

        /// <summary>
        /// Handles trying to simulate a user logging in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLoginButton_Click(object sender, EventArgs e)
        {
            var m = new Mensaje(State.Login, new User(new Contact(uxUsernameTB.Text, Status.Online), uxPasswordTB.Text, "1234"));

            _handle(m, "1234");
            foreach (var tb in _testingTextBoxes) tb.Clear();
        }
        /// <summary>
        /// Handles simulating a user adding a contact.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAddCnctBtn_Click(object sender, EventArgs e)
        {
            var m = new Mensaje(State.AddContact, new Contact(uxContactTB.Text, Status.Online), new User(new Contact(uxUsernameTB.Text, Status.Online), null, "1234"));

            _handle(m, "1234");
            foreach (var tb in _testingTextBoxes) tb.Clear();
        }
        /// <summary>
        /// Handles simulating a user removing a contact.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxRmvCnctBtn_Click(object sender, EventArgs e)
        {
            var m = new Mensaje(State.RemoveContact, new Contact(uxContactTB.Text, Status.Online), new User(new Contact(uxUsernameTB.Text, Status.Online), null, "1234"));

            _handle(m, "1234");
            foreach (var tb in _testingTextBoxes) tb.Clear();
        }
        /// <summary>
        /// Handles simulating a user creating a chat room
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxCreateChatRoomBtn_Click(object sender, EventArgs e)
        {
            var u1 = new User(new Contact(uxUsernameTB.Text, Status.Online), null, null);
            var u2 = new User(new Contact(uxContactTB.Text, Status.Online), null, null);

            var m = new Mensaje(new ChatRoom(null, u1, u2), u1);

            _handle(m, "1234");
            foreach (var tb in _testingTextBoxes) tb.Clear();
        }
        /// <summary>
        /// Handles simulating a user sending a text message to a chat room.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSendMessageBtn_Click(object sender, EventArgs e)
        {
            var m = new Mensaje(new ChatRoom(uxChatRoomIdTB.Text), new TextMessage(uxMessageTB.Text, new Contact(uxUsernameTB.Text, Status.Online)));
            _handle(m, "1234");
            foreach (var tb in _testingTextBoxes) tb.Clear();

        }
        /// <summary>
        /// Handles simulating a user logging out.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLogoutButton_Click(object sender, EventArgs e)
        {
            var m = new Mensaje(State.Logout, new User(new Contact(uxUsernameTB.Text, Status.Offline), null, "1234"));
            _handle(m, "1234");
            foreach (var tb in _testingTextBoxes) tb.Clear();
        }

        /// <summary>
        /// Method called from the controller that will update the EventLog list view.
        /// </summary>
        /// <param name="m">The mensaje containing information to display.</param>
        /// <param name="s">The status of the server, either send, receive, or internal.</param>
        public void SendEvent(IMensaje m, LogStatus s)
        {
            var ms = new List<string>(((Mensaje)m).ArrayString)
            {
                s.ToString()
            };
            var lt = new ListViewItem(ms.ToArray());

            if (uxUsersListView.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate { uxEventLogListView.Items.Add(lt); }));
            }
            else
            {
                uxEventLogListView.Items.Add(lt);
            }
        }
        /// <summary>
        /// Clears the user list view and then updates it to all contained in the database.
        /// </summary>
        public void UpdateUserListView()
        {
            if (uxUsersListView.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate { uxUsersListView.BeginUpdate(); }));
                Invoke(new MethodInvoker(delegate { uxUsersListView.Items.Clear(); }));

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
                uxUsersListView.Items.Clear();
                foreach (var u in _db.Users)
                {
                    string[] s = { u.ContactInfo.Username };
                    var li = new ListViewItem(s);
                    uxUsersListView.Items.Add(li);
                }
                uxUsersListView.EndUpdate();
            }
        }
        /// <summary>
        /// Called after selecting a row in the user list view. Updates the web browser to show all the information about each client selected.
        /// </summary>
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
        /// <summary>
        /// Updates the chat room web browser to show all the chat rooms open and the information inside them.
        /// </summary>
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

        /// <summary>
        /// Handles the user selecting a different user in the user list view. 
        /// Will update the list of strings of all users that are selected, then call the update user web browser method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Handles enabling or disabling the testing tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = ((ToolStripComboBox)sender).SelectedIndex;

            foreach (var u in _testingButtons) u.Enabled =  index == 1;
            foreach (var u in _testingTextBoxes) u.Enabled = index == 1;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ServerForm_Load(object sender, System.EventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
