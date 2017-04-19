using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();

            //listView1.Columns.Add("Time");
            //listView1.Columns.Add("Invoked by User");
            //listView1.Columns.Add("Successful");
            //listView1.Columns.Add("Message");
            //listView1.Columns[1].Text = "First";
            //listView1.Columns[2].Text = "Second";
            //listView1.Columns[3].Text = "One index";

            string[] row = { "Hey", "what's", "up", "yes" };

            for (int i = 0; i < 20; i++)
            {
                var lt1 = new ListViewItem("Heyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy");
                listView1.Items.Add(lt1);
            }
            var lt = new ListViewItem("Hey1");
            listView1.Items.Add(lt);
            Refresh();
        }
    }
}
