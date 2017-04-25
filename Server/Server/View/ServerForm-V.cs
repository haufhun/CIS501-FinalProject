using System;
using System.Windows.Forms;
using Server.Model;

namespace Server.View
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();

            listView1.Columns.Add("Time");
            listView1.Columns.Add("Invoked by User");
            listView1.Columns.Add("Successful");
            listView1.Columns.Add("Message");
            listView1.Columns.Add("State");
            listView1.Columns.Add("Send/Receive");


            //listView1.Columns[1].Text = "First";
            //listView1.Columns[2].Text = "Second";
            //listView1.Columns[3].Text = "One index";

        }

        public void SendEvent(Mensaje m)
        {
                            //      The time                The Username                SessionId of User       The state           //Send/Receive
            string [] row = { DateTime.Now.ToString(), m.User.ContactInfo.Username, ((User)m.User).SessionId, m.MyState.ToString() };

            var lt = new ListViewItem(row);
            listView1.Items.Add(lt);
        }
    }
}
