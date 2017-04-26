using System;
using System.Windows.Forms;
using Server.Model;
using Chat_CSLibrary;
using static Server.Delegates;

namespace Server.View
{
    public partial class ServerForm : Form
    {
        private InputHandler _handle;

        public ServerForm(InputHandler h)
        {
            _handle = h;

            InitializeComponent();

            listView1.Columns.Add("Time");
            listView1.Columns.Add("User");
            listView1.Columns.Add("Session Id");
            listView1.Columns.Add("State");
            listView1.Columns.Add("New User?");
            listView1.Columns.Add("Error?");
            listView1.Columns.Add("Error Message");
            listView1.Columns.Add("Chat Room Id");


            //listView1.Columns[1].Text = "First";
            //listView1.Columns[2].Text = "Second";
            //listView1.Columns[3].Text = "One index";

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
    }
}
