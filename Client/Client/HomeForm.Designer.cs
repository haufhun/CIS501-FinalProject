namespace Client
{
    partial class HomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.listView1 = new System.Windows.Forms.ListView();
            this.uxNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.uxStartChat = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.uxDeleteContact = new System.Windows.Forms.ToolStripButton();
            this.uxSignOut = new System.Windows.Forms.ToolStripButton();
            this.uxInfoLabel = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.uxNameCol,
            this.uxStatus});
            this.listView1.Location = new System.Drawing.Point(12, 37);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(355, 314);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // uxNameCol
            // 
            this.uxNameCol.Text = "Name";
            this.uxNameCol.Width = 162;
            // 
            // uxStatus
            // 
            this.uxStatus.Text = "Status";
            this.uxStatus.Width = 119;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxStartChat,
            this.toolStripButton2,
            this.uxDeleteContact,
            this.uxSignOut});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(639, 27);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // uxStartChat
            // 
            this.uxStartChat.Image = ((System.Drawing.Image)(resources.GetObject("uxStartChat.Image")));
            this.uxStartChat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxStartChat.Name = "uxStartChat";
            this.uxStartChat.Size = new System.Drawing.Size(98, 24);
            this.uxStartChat.Text = "Start Chat";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(116, 24);
            this.toolStripButton2.Text = "Add Contact";
            this.toolStripButton2.ToolTipText = "uxAddContact";
            // 
            // uxDeleteContact
            // 
            this.uxDeleteContact.Image = ((System.Drawing.Image)(resources.GetObject("uxDeleteContact.Image")));
            this.uxDeleteContact.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxDeleteContact.Name = "uxDeleteContact";
            this.uxDeleteContact.Size = new System.Drawing.Size(132, 24);
            this.uxDeleteContact.Text = "Delete Contact";
            // 
            // uxSignOut
            // 
            this.uxSignOut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.uxSignOut.Image = ((System.Drawing.Image)(resources.GetObject("uxSignOut.Image")));
            this.uxSignOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxSignOut.Name = "uxSignOut";
            this.uxSignOut.Size = new System.Drawing.Size(90, 24);
            this.uxSignOut.Text = "Sign Out";
            // 
            // uxInfoLabel
            // 
            this.uxInfoLabel.AutoSize = true;
            this.uxInfoLabel.Location = new System.Drawing.Point(393, 74);
            this.uxInfoLabel.Name = "uxInfoLabel";
            this.uxInfoLabel.Size = new System.Drawing.Size(112, 17);
            this.uxInfoLabel.TabIndex = 4;
            this.uxInfoLabel.Text = "Information label";
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 390);
            this.Controls.Add(this.uxInfoLabel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HomeForm";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader uxNameCol;
        private System.Windows.Forms.ColumnHeader uxStatus;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton uxStartChat;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton uxDeleteContact;
        private System.Windows.Forms.ToolStripButton uxSignOut;
        private System.Windows.Forms.Label uxInfoLabel;
    }
}

