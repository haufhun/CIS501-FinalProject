using System;
using System.Windows.Forms;
using Server.Model;
using Chat_CSLibrary;

namespace Server.View
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
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
            var m = new Mensaje(new User(new Contact("Hunter", Chat_CSLibrary.Status.Online), "password", "123"), false);

            SendEvent(m);
        }
    }
}
