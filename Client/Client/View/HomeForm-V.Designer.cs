namespace Client.View
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
            this.uxAddContact = new System.Windows.Forms.ToolStripButton();
            this.uxDeleteContact = new System.Windows.Forms.ToolStripButton();
            this.uxSignOut = new System.Windows.Forms.ToolStripButton();
            this.uxInfoLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.uxColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uxColStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.uxAddContact,
            this.uxDeleteContact,
            this.uxSignOut});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(526, 27);
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
            this.uxStartChat.Click += new System.EventHandler(this.uxStartChat_Click);
            // 
            // uxAddContact
            // 
            this.uxAddContact.Image = ((System.Drawing.Image)(resources.GetObject("uxAddContact.Image")));
            this.uxAddContact.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxAddContact.Name = "uxAddContact";
            this.uxAddContact.Size = new System.Drawing.Size(116, 24);
            this.uxAddContact.Text = "Add Contact";
            this.uxAddContact.ToolTipText = "uxAddContact";
            this.uxAddContact.Click += new System.EventHandler(this.uxAddContact_Click);
            // 
            // uxDeleteContact
            // 
            this.uxDeleteContact.Image = ((System.Drawing.Image)(resources.GetObject("uxDeleteContact.Image")));
            this.uxDeleteContact.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxDeleteContact.Name = "uxDeleteContact";
            this.uxDeleteContact.Size = new System.Drawing.Size(142, 24);
            this.uxDeleteContact.Text = "Remove Contact";
            this.uxDeleteContact.Click += new System.EventHandler(this.uxDeleteContact_Click);
            // 
            // uxSignOut
            // 
            this.uxSignOut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.uxSignOut.Image = ((System.Drawing.Image)(resources.GetObject("uxSignOut.Image")));
            this.uxSignOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxSignOut.Name = "uxSignOut";
            this.uxSignOut.Size = new System.Drawing.Size(90, 24);
            this.uxSignOut.Text = "Sign Out";
            this.uxSignOut.Click += new System.EventHandler(this.uxSignOut_Click);
            // 
            // uxInfoLabel
            // 
            this.uxInfoLabel.AutoSize = true;
            this.uxInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxInfoLabel.Location = new System.Drawing.Point(429, 135);
            this.uxInfoLabel.Name = "uxInfoLabel";
            this.uxInfoLabel.Size = new System.Drawing.Size(45, 20);
            this.uxInfoLabel.TabIndex = 4;
            this.uxInfoLabel.Text = "info?";
            this.uxInfoLabel.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uxColName,
            this.uxColStatus});
            this.dataGridView1.Location = new System.Drawing.Point(99, 135);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(169, 136);
            this.dataGridView1.TabIndex = 11;
            // 
            // uxColName
            // 
            this.uxColName.HeaderText = "Name";
            this.uxColName.Name = "uxColName";
            this.uxColName.ReadOnly = true;
            // 
            // uxColStatus
            // 
            this.uxColStatus.HeaderText = "Status";
            this.uxColStatus.Name = "uxColStatus";
            this.uxColStatus.ReadOnly = true;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 390);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.uxInfoLabel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HomeForm";
            this.Text = "Home";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader uxNameCol;
        private System.Windows.Forms.ColumnHeader uxStatus;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton uxStartChat;
        private System.Windows.Forms.ToolStripButton uxAddContact;
        private System.Windows.Forms.ToolStripButton uxDeleteContact;
        private System.Windows.Forms.ToolStripButton uxSignOut;
        private System.Windows.Forms.Label uxInfoLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn uxColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn uxColStatus;
    }
}

