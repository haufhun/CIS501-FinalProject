namespace Server.View
{
    partial class ServerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.uxChatMsgsWebBrowser = new System.Windows.Forms.WebBrowser();
            this.label7 = new System.Windows.Forms.Label();
            this.uxUsersWebBrowser = new System.Windows.Forms.WebBrowser();
            this.uxUsersListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.uxMessageTB = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.uxChatRoomIdTB = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.uxSendMessageBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.uxLogoutButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.uxCreateChatRoomBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.uxAddCnctBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uxContactTB = new System.Windows.Forms.TextBox();
            this.uxPasswordTB = new System.Windows.Forms.TextBox();
            this.uxUsernameTB = new System.Windows.Forms.TextBox();
            this.uxRmvCnctBtn = new System.Windows.Forms.Button();
            this.uxLoginButton = new System.Windows.Forms.Button();
            this.uxEventLogTabPage = new System.Windows.Forms.TabPage();
            this.uxEventLogListView = new System.Windows.Forms.ListView();
            this.uxTabControl = new System.Windows.Forms.TabControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.uxEventLogTabPage.SuspendLayout();
            this.uxTabControl.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.uxChatMsgsWebBrowser);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.uxUsersWebBrowser);
            this.tabPage1.Controls.Add(this.uxUsersListView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(964, 613);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Database";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // uxChatMsgsWebBrowser
            // 
            this.uxChatMsgsWebBrowser.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.uxChatMsgsWebBrowser.Location = new System.Drawing.Point(615, 41);
            this.uxChatMsgsWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.uxChatMsgsWebBrowser.Name = "uxChatMsgsWebBrowser";
            this.uxChatMsgsWebBrowser.Size = new System.Drawing.Size(326, 467);
            this.uxChatMsgsWebBrowser.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(182, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Select any number of users to display";
            // 
            // uxUsersWebBrowser
            // 
            this.uxUsersWebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxUsersWebBrowser.Location = new System.Drawing.Point(233, 41);
            this.uxUsersWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.uxUsersWebBrowser.Name = "uxUsersWebBrowser";
            this.uxUsersWebBrowser.Size = new System.Drawing.Size(347, 467);
            this.uxUsersWebBrowser.TabIndex = 1;
            this.uxUsersWebBrowser.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // uxUsersListView
            // 
            this.uxUsersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.uxUsersListView.FullRowSelect = true;
            this.uxUsersListView.GridLines = true;
            this.uxUsersListView.Location = new System.Drawing.Point(8, 41);
            this.uxUsersListView.Name = "uxUsersListView";
            this.uxUsersListView.Size = new System.Drawing.Size(198, 474);
            this.uxUsersListView.TabIndex = 0;
            this.uxUsersListView.UseCompatibleStateImageBehavior = false;
            this.uxUsersListView.View = System.Windows.Forms.View.Details;
            this.uxUsersListView.SelectedIndexChanged += new System.EventHandler(this.uxUsersListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Users";
            this.columnHeader1.Width = 189;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.uxMessageTB);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.uxChatRoomIdTB);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.uxSendMessageBtn);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.uxLogoutButton);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.uxCreateChatRoomBtn);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.uxAddCnctBtn);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.uxContactTB);
            this.tabPage2.Controls.Add(this.uxPasswordTB);
            this.tabPage2.Controls.Add(this.uxUsernameTB);
            this.tabPage2.Controls.Add(this.uxRmvCnctBtn);
            this.tabPage2.Controls.Add(this.uxLoginButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(964, 613);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Testing";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(42, 223);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Chat Message";
            // 
            // uxMessageTB
            // 
            this.uxMessageTB.Location = new System.Drawing.Point(127, 223);
            this.uxMessageTB.Name = "uxMessageTB";
            this.uxMessageTB.Size = new System.Drawing.Size(100, 20);
            this.uxMessageTB.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(42, 183);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Chat Room Id";
            // 
            // uxChatRoomIdTB
            // 
            this.uxChatRoomIdTB.Location = new System.Drawing.Point(127, 183);
            this.uxChatRoomIdTB.Name = "uxChatRoomIdTB";
            this.uxChatRoomIdTB.Size = new System.Drawing.Size(100, 20);
            this.uxChatRoomIdTB.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(440, 221);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(166, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Fill in ChatRoomID and Username";
            // 
            // uxSendMessageBtn
            // 
            this.uxSendMessageBtn.Location = new System.Drawing.Point(322, 218);
            this.uxSendMessageBtn.Name = "uxSendMessageBtn";
            this.uxSendMessageBtn.Size = new System.Drawing.Size(112, 23);
            this.uxSendMessageBtn.TabIndex = 17;
            this.uxSendMessageBtn.Text = "Send Message";
            this.uxSendMessageBtn.UseVisualStyleBackColor = true;
            this.uxSendMessageBtn.Click += new System.EventHandler(this.uxSendMessageBtn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(439, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Fill in username";
            // 
            // uxLogoutButton
            // 
            this.uxLogoutButton.Location = new System.Drawing.Point(337, 47);
            this.uxLogoutButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxLogoutButton.Name = "uxLogoutButton";
            this.uxLogoutButton.Size = new System.Drawing.Size(75, 24);
            this.uxLogoutButton.TabIndex = 15;
            this.uxLogoutButton.Text = "LogOut";
            this.uxLogoutButton.UseVisualStyleBackColor = true;
            this.uxLogoutButton.Click += new System.EventHandler(this.uxLogoutButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(440, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Fill in username and Contact name";
            // 
            // uxCreateChatRoomBtn
            // 
            this.uxCreateChatRoomBtn.Location = new System.Drawing.Point(322, 178);
            this.uxCreateChatRoomBtn.Name = "uxCreateChatRoomBtn";
            this.uxCreateChatRoomBtn.Size = new System.Drawing.Size(112, 23);
            this.uxCreateChatRoomBtn.TabIndex = 12;
            this.uxCreateChatRoomBtn.Text = "Create Chat Room";
            this.uxCreateChatRoomBtn.UseVisualStyleBackColor = true;
            this.uxCreateChatRoomBtn.Click += new System.EventHandler(this.uxCreateChatRoomBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(440, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fill in username and Contact name";
            // 
            // uxAddCnctBtn
            // 
            this.uxAddCnctBtn.Location = new System.Drawing.Point(322, 88);
            this.uxAddCnctBtn.Name = "uxAddCnctBtn";
            this.uxAddCnctBtn.Size = new System.Drawing.Size(112, 23);
            this.uxAddCnctBtn.TabIndex = 10;
            this.uxAddCnctBtn.Text = "Add Contact";
            this.uxAddCnctBtn.UseVisualStyleBackColor = true;
            this.uxAddCnctBtn.Click += new System.EventHandler(this.uxAddCnctBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(440, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fill in username and Contact name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(439, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fill in username and password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Contact Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Username";
            // 
            // uxContactTB
            // 
            this.uxContactTB.Location = new System.Drawing.Point(127, 108);
            this.uxContactTB.Name = "uxContactTB";
            this.uxContactTB.Size = new System.Drawing.Size(100, 20);
            this.uxContactTB.TabIndex = 4;
            // 
            // uxPasswordTB
            // 
            this.uxPasswordTB.Location = new System.Drawing.Point(127, 60);
            this.uxPasswordTB.Name = "uxPasswordTB";
            this.uxPasswordTB.Size = new System.Drawing.Size(100, 20);
            this.uxPasswordTB.TabIndex = 3;
            // 
            // uxUsernameTB
            // 
            this.uxUsernameTB.Location = new System.Drawing.Point(127, 22);
            this.uxUsernameTB.Name = "uxUsernameTB";
            this.uxUsernameTB.Size = new System.Drawing.Size(100, 20);
            this.uxUsernameTB.TabIndex = 2;
            // 
            // uxRmvCnctBtn
            // 
            this.uxRmvCnctBtn.Location = new System.Drawing.Point(322, 117);
            this.uxRmvCnctBtn.Name = "uxRmvCnctBtn";
            this.uxRmvCnctBtn.Size = new System.Drawing.Size(112, 23);
            this.uxRmvCnctBtn.TabIndex = 1;
            this.uxRmvCnctBtn.Text = "Remove Contact";
            this.uxRmvCnctBtn.UseVisualStyleBackColor = true;
            this.uxRmvCnctBtn.Click += new System.EventHandler(this.uxRmvCnctBtn_Click);
            // 
            // uxLoginButton
            // 
            this.uxLoginButton.Location = new System.Drawing.Point(337, 19);
            this.uxLoginButton.Name = "uxLoginButton";
            this.uxLoginButton.Size = new System.Drawing.Size(75, 23);
            this.uxLoginButton.TabIndex = 0;
            this.uxLoginButton.Text = "Login";
            this.uxLoginButton.UseVisualStyleBackColor = true;
            this.uxLoginButton.Click += new System.EventHandler(this.uxLoginButton_Click);
            // 
            // uxEventLogTabPage
            // 
            this.uxEventLogTabPage.Controls.Add(this.uxEventLogListView);
            this.uxEventLogTabPage.Location = new System.Drawing.Point(4, 22);
            this.uxEventLogTabPage.Name = "uxEventLogTabPage";
            this.uxEventLogTabPage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.uxEventLogTabPage.Size = new System.Drawing.Size(964, 613);
            this.uxEventLogTabPage.TabIndex = 0;
            this.uxEventLogTabPage.Text = "Event Log";
            this.uxEventLogTabPage.UseVisualStyleBackColor = true;
            // 
            // uxEventLogListView
            // 
            this.uxEventLogListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxEventLogListView.FullRowSelect = true;
            this.uxEventLogListView.GridLines = true;
            this.uxEventLogListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.uxEventLogListView.Location = new System.Drawing.Point(11, 8);
            this.uxEventLogListView.Name = "uxEventLogListView";
            this.uxEventLogListView.Size = new System.Drawing.Size(950, 648);
            this.uxEventLogListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.uxEventLogListView.TabIndex = 0;
            this.uxEventLogListView.UseCompatibleStateImageBehavior = false;
            this.uxEventLogListView.View = System.Windows.Forms.View.Details;
            this.uxEventLogListView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // uxTabControl
            // 
            this.uxTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxTabControl.Controls.Add(this.uxEventLogTabPage);
            this.uxTabControl.Controls.Add(this.tabPage2);
            this.uxTabControl.Controls.Add(this.tabPage1);
            this.uxTabControl.Location = new System.Drawing.Point(0, 26);
            this.uxTabControl.Name = "uxTabControl";
            this.uxTabControl.SelectedIndex = 0;
            this.uxTabControl.Size = new System.Drawing.Size(972, 639);
            this.uxTabControl.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(957, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "Testing Off",
            "Testing On"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox1.Text = "<Error!>";
            this.toolStripComboBox1.ToolTipText = "Sets if the testing page is enabled or not.";
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 628);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.uxTabControl);
            this.Name = "ServerForm";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.uxEventLogTabPage.ResumeLayout(false);
            this.uxTabControl.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.WebBrowser uxUsersWebBrowser;
        private System.Windows.Forms.ListView uxUsersListView;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button uxAddCnctBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uxContactTB;
        private System.Windows.Forms.TextBox uxPasswordTB;
        private System.Windows.Forms.TextBox uxUsernameTB;
        private System.Windows.Forms.Button uxRmvCnctBtn;
        private System.Windows.Forms.Button uxLoginButton;
        private System.Windows.Forms.TabPage uxEventLogTabPage;
        private System.Windows.Forms.ListView uxEventLogListView;
        private System.Windows.Forms.TabControl uxTabControl;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.Button uxCreateChatRoomBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.WebBrowser uxChatMsgsWebBrowser;
        private System.Windows.Forms.Button uxLogoutButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox uxMessageTB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox uxChatRoomIdTB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button uxSendMessageBtn;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

