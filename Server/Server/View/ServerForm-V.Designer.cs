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
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            this.uxTabControl = new System.Windows.Forms.TabControl();
            this.uxEventLogTabPage = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.uxRmvCnctBtn = new System.Windows.Forms.Button();
            this.uxLoginButton = new System.Windows.Forms.Button();
            this.uxUsernameTB = new System.Windows.Forms.TextBox();
            this.uxPasswordTB = new System.Windows.Forms.TextBox();
            this.uxContactTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.uxAddCnctBtn = new System.Windows.Forms.Button();
            this.uxTabControl.SuspendLayout();
            this.uxEventLogTabPage.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxTabControl
            // 
            this.uxTabControl.Controls.Add(this.uxEventLogTabPage);
            this.uxTabControl.Controls.Add(this.tabPage2);
            this.uxTabControl.Location = new System.Drawing.Point(0, 0);
            this.uxTabControl.Name = "uxTabControl";
            this.uxTabControl.SelectedIndex = 0;
            this.uxTabControl.Size = new System.Drawing.Size(790, 612);
            this.uxTabControl.TabIndex = 0;
            // 
            // uxEventLogTabPage
            // 
            this.uxEventLogTabPage.Controls.Add(this.listView1);
            this.uxEventLogTabPage.Location = new System.Drawing.Point(4, 22);
            this.uxEventLogTabPage.Name = "uxEventLogTabPage";
            this.uxEventLogTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.uxEventLogTabPage.Size = new System.Drawing.Size(782, 586);
            this.uxEventLogTabPage.TabIndex = 0;
            this.uxEventLogTabPage.Text = "Event Log";
            this.uxEventLogTabPage.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.GridLines = true;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.listView1.Location = new System.Drawing.Point(8, 6);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(765, 557);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // tabPage2
            // 
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
            this.tabPage2.Size = new System.Drawing.Size(782, 586);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // uxRmvCnctBtn
            // 
            this.uxRmvCnctBtn.Location = new System.Drawing.Point(371, 90);
            this.uxRmvCnctBtn.Name = "uxRmvCnctBtn";
            this.uxRmvCnctBtn.Size = new System.Drawing.Size(112, 23);
            this.uxRmvCnctBtn.TabIndex = 1;
            this.uxRmvCnctBtn.Text = "Remove Contact";
            this.uxRmvCnctBtn.UseVisualStyleBackColor = true;
            this.uxRmvCnctBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // uxLoginButton
            // 
            this.uxLoginButton.Location = new System.Drawing.Point(387, 11);
            this.uxLoginButton.Name = "uxLoginButton";
            this.uxLoginButton.Size = new System.Drawing.Size(75, 23);
            this.uxLoginButton.TabIndex = 0;
            this.uxLoginButton.Text = "Login";
            this.uxLoginButton.UseVisualStyleBackColor = true;
            this.uxLoginButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // uxUsernameTB
            // 
            this.uxUsernameTB.Location = new System.Drawing.Point(177, 14);
            this.uxUsernameTB.Name = "uxUsernameTB";
            this.uxUsernameTB.Size = new System.Drawing.Size(100, 20);
            this.uxUsernameTB.TabIndex = 2;
            // 
            // uxPasswordTB
            // 
            this.uxPasswordTB.Location = new System.Drawing.Point(177, 52);
            this.uxPasswordTB.Name = "uxPasswordTB";
            this.uxPasswordTB.Size = new System.Drawing.Size(100, 20);
            this.uxPasswordTB.TabIndex = 3;
            // 
            // uxContactTB
            // 
            this.uxContactTB.Location = new System.Drawing.Point(177, 100);
            this.uxContactTB.Name = "uxContactTB";
            this.uxContactTB.Size = new System.Drawing.Size(100, 20);
            this.uxContactTB.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Contact Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(468, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fill in username and password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(489, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fill in username and Contact name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(489, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fill in username and Contact name";
            // 
            // uxAddCnctBtn
            // 
            this.uxAddCnctBtn.Location = new System.Drawing.Point(371, 61);
            this.uxAddCnctBtn.Name = "uxAddCnctBtn";
            this.uxAddCnctBtn.Size = new System.Drawing.Size(112, 23);
            this.uxAddCnctBtn.TabIndex = 10;
            this.uxAddCnctBtn.Text = "Add Contact";
            this.uxAddCnctBtn.UseVisualStyleBackColor = true;
            this.uxAddCnctBtn.Click += new System.EventHandler(this.uxAddCnctBtn_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 607);
            this.Controls.Add(this.uxTabControl);
            this.Name = "ServerForm";
            this.Text = "Form1";
            this.uxTabControl.ResumeLayout(false);
            this.uxEventLogTabPage.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl uxTabControl;
        private System.Windows.Forms.TabPage uxEventLogTabPage;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button uxLoginButton;
        private System.Windows.Forms.Button uxRmvCnctBtn;
        private System.Windows.Forms.TextBox uxPasswordTB;
        private System.Windows.Forms.TextBox uxUsernameTB;
        private System.Windows.Forms.TextBox uxContactTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button uxAddCnctBtn;
    }
}

