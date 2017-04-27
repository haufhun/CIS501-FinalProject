namespace Client
{
    partial class ChatForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatForm));
            this.messageLabel = new System.Windows.Forms.Label();
            this.uxMessageTextBox = new System.Windows.Forms.TextBox();
            this.messageListBox = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.uxEndChat = new System.Windows.Forms.ToolStripButton();
            this.listView1 = new System.Windows.Forms.ListView();
            this.uxNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.uxColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uxColStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uxSend = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(388, 269);
            this.messageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(69, 17);
            this.messageLabel.TabIndex = 7;
            this.messageLabel.Text = "Message:";
            // 
            // uxMessageTextBox
            // 
            this.uxMessageTextBox.Location = new System.Drawing.Point(471, 265);
            this.uxMessageTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.uxMessageTextBox.Name = "uxMessageTextBox";
            this.uxMessageTextBox.Size = new System.Drawing.Size(427, 22);
            this.uxMessageTextBox.TabIndex = 6;
            // 
            // messageListBox
            // 
            this.messageListBox.FormattingEnabled = true;
            this.messageListBox.ItemHeight = 16;
            this.messageListBox.Location = new System.Drawing.Point(391, 39);
            this.messageListBox.Margin = new System.Windows.Forms.Padding(4);
            this.messageListBox.Name = "messageListBox";
            this.messageListBox.Size = new System.Drawing.Size(507, 212);
            this.messageListBox.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.uxEndChat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(919, 27);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(214, 24);
            this.toolStripButton2.Text = "Add Contact To Chat Room";
            this.toolStripButton2.ToolTipText = "uxAddContact";
            // 
            // uxEndChat
            // 
            this.uxEndChat.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.uxEndChat.Image = ((System.Drawing.Image)(resources.GetObject("uxEndChat.Image")));
            this.uxEndChat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxEndChat.Name = "uxEndChat";
            this.uxEndChat.Size = new System.Drawing.Size(92, 24);
            this.uxEndChat.Text = "End Chat";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.uxNameCol,
            this.uxStatus});
            this.listView1.Location = new System.Drawing.Point(12, 38);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(355, 310);
            this.listView1.TabIndex = 8;
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uxColName,
            this.uxColStatus});
            this.dataGridView1.Location = new System.Drawing.Point(44, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(259, 208);
            this.dataGridView1.TabIndex = 10;
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
            // uxSend
            // 
            this.uxSend.Location = new System.Drawing.Point(537, 310);
            this.uxSend.Name = "uxSend";
            this.uxSend.Size = new System.Drawing.Size(295, 38);
            this.uxSend.TabIndex = 11;
            this.uxSend.Text = "Send";
            this.uxSend.UseVisualStyleBackColor = true;
            this.uxSend.Click += new System.EventHandler(this.uxSend_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 360);
            this.Controls.Add(this.uxSend);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.uxMessageTextBox);
            this.Controls.Add(this.messageListBox);
            this.Name = "ChatForm";
            this.Text = "ChatForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.TextBox uxMessageTextBox;
        private System.Windows.Forms.ListBox messageListBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton uxEndChat;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader uxNameCol;
        private System.Windows.Forms.ColumnHeader uxStatus;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn uxColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn uxColStatus;
        private System.Windows.Forms.Button uxSend;
    }
}