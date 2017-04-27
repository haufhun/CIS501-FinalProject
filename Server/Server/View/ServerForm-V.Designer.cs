﻿namespace Server.View
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
            this.uxChatRoomListView = new System.Windows.Forms.ListView();
            this.label7 = new System.Windows.Forms.Label();
            this.uxUsersWebBrowser = new System.Windows.Forms.WebBrowser();
            this.uxUsersListView = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.uxTabControl = new System.Windows.Forms.TabControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.uxChatMsgsWebBrowser = new System.Windows.Forms.WebBrowser();
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
            this.tabPage1.Controls.Add(this.uxChatRoomListView);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.uxUsersWebBrowser);
            this.tabPage1.Controls.Add(this.uxUsersListView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(964, 597);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Database";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // uxChatRoomListView
            // 
            this.uxChatRoomListView.Location = new System.Drawing.Point(6, 297);
            this.uxChatRoomListView.Name = "uxChatRoomListView";
            this.uxChatRoomListView.Size = new System.Drawing.Size(200, 246);
            this.uxChatRoomListView.TabIndex = 3;
            this.uxChatRoomListView.UseCompatibleStateImageBehavior = false;
            this.uxChatRoomListView.View = System.Windows.Forms.View.Details;
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
            this.uxUsersWebBrowser.Size = new System.Drawing.Size(713, 234);
            this.uxUsersWebBrowser.TabIndex = 1;
            this.uxUsersWebBrowser.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // uxUsersListView
            // 
            this.uxUsersListView.Location = new System.Drawing.Point(8, 41);
            this.uxUsersListView.Name = "uxUsersListView";
            this.uxUsersListView.Size = new System.Drawing.Size(200, 234);
            this.uxUsersListView.TabIndex = 0;
            this.uxUsersListView.UseCompatibleStateImageBehavior = false;
            this.uxUsersListView.View = System.Windows.Forms.View.List;
            this.uxUsersListView.SelectedIndexChanged += new System.EventHandler(this.uxUsersListView_SelectedIndexChanged);
            // 
            // tabPage2
            // 
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
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(964, 597);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Testing";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(439, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Fill in username and Contact name";
            // 
            // uxCreateChatRoomBtn
            // 
            this.uxCreateChatRoomBtn.Location = new System.Drawing.Point(321, 128);
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
            this.label6.Location = new System.Drawing.Point(439, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fill in username and Contact name";
            // 
            // uxAddCnctBtn
            // 
            this.uxAddCnctBtn.Location = new System.Drawing.Point(321, 69);
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
            this.label5.Location = new System.Drawing.Point(439, 103);
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
            this.uxRmvCnctBtn.Location = new System.Drawing.Point(321, 98);
            this.uxRmvCnctBtn.Name = "uxRmvCnctBtn";
            this.uxRmvCnctBtn.Size = new System.Drawing.Size(112, 23);
            this.uxRmvCnctBtn.TabIndex = 1;
            this.uxRmvCnctBtn.Text = "Remove Contact";
            this.uxRmvCnctBtn.UseVisualStyleBackColor = true;
            this.uxRmvCnctBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // uxLoginButton
            // 
            this.uxLoginButton.Location = new System.Drawing.Point(337, 19);
            this.uxLoginButton.Name = "uxLoginButton";
            this.uxLoginButton.Size = new System.Drawing.Size(75, 23);
            this.uxLoginButton.TabIndex = 0;
            this.uxLoginButton.Text = "Login";
            this.uxLoginButton.UseVisualStyleBackColor = true;
            this.uxLoginButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // uxEventLogTabPage
            // 
            this.uxEventLogTabPage.Controls.Add(this.listView1);
            this.uxEventLogTabPage.Location = new System.Drawing.Point(4, 22);
            this.uxEventLogTabPage.Name = "uxEventLogTabPage";
            this.uxEventLogTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.uxEventLogTabPage.Size = new System.Drawing.Size(964, 597);
            this.uxEventLogTabPage.TabIndex = 0;
            this.uxEventLogTabPage.Text = "Event Log";
            this.uxEventLogTabPage.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.GridLines = true;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.Location = new System.Drawing.Point(8, 6);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(950, 630);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // uxTabControl
            // 
            this.uxTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxTabControl.Controls.Add(this.uxEventLogTabPage);
            this.uxTabControl.Controls.Add(this.tabPage2);
            this.uxTabControl.Controls.Add(this.tabPage1);
            this.uxTabControl.Location = new System.Drawing.Point(0, 42);
            this.uxTabControl.Name = "uxTabControl";
            this.uxTabControl.SelectedIndex = 0;
            this.uxTabControl.Size = new System.Drawing.Size(972, 623);
            this.uxTabControl.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
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
            // uxChatMsgsWebBrowser
            // 
            this.uxChatMsgsWebBrowser.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.uxChatMsgsWebBrowser.Location = new System.Drawing.Point(233, 297);
            this.uxChatMsgsWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.uxChatMsgsWebBrowser.Name = "uxChatMsgsWebBrowser";
            this.uxChatMsgsWebBrowser.Size = new System.Drawing.Size(250, 250);
            this.uxChatMsgsWebBrowser.TabIndex = 4;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 677);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.uxTabControl);
            this.Name = "ServerForm";
            this.Text = "Form1";
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
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TabControl uxTabControl;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.Button uxCreateChatRoomBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView uxChatRoomListView;
        private System.Windows.Forms.WebBrowser uxChatMsgsWebBrowser;
    }
}

