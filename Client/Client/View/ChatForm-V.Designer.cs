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
            this.uxMessageListBox = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.uxAddContact = new System.Windows.Forms.ToolStripButton();
            this.uxEndChat = new System.Windows.Forms.ToolStripButton();
            this.uxListView = new System.Windows.Forms.ListView();
            this.uxNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxSend = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.Location = new System.Drawing.Point(388, 269);
            this.messageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(99, 25);
            this.messageLabel.TabIndex = 7;
            this.messageLabel.Text = "Message:";
            // 
            // uxMessageTextBox
            // 
            this.uxMessageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxMessageTextBox.Location = new System.Drawing.Point(495, 265);
            this.uxMessageTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.uxMessageTextBox.Multiline = true;
            this.uxMessageTextBox.Name = "uxMessageTextBox";
            this.uxMessageTextBox.Size = new System.Drawing.Size(434, 38);
            this.uxMessageTextBox.TabIndex = 6;
            // 
            // uxMessageListBox
            // 
            this.uxMessageListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxMessageListBox.FormattingEnabled = true;
            this.uxMessageListBox.ItemHeight = 16;
            this.uxMessageListBox.Location = new System.Drawing.Point(391, 39);
            this.uxMessageListBox.Margin = new System.Windows.Forms.Padding(4);
            this.uxMessageListBox.Name = "uxMessageListBox";
            this.uxMessageListBox.Size = new System.Drawing.Size(538, 212);
            this.uxMessageListBox.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxAddContact,
            this.uxEndChat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(950, 27);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // uxAddContact
            // 
            this.uxAddContact.Image = ((System.Drawing.Image)(resources.GetObject("uxAddContact.Image")));
            this.uxAddContact.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxAddContact.Name = "uxAddContact";
            this.uxAddContact.Size = new System.Drawing.Size(214, 24);
            this.uxAddContact.Text = "Add Contact To Chat Room";
            this.uxAddContact.ToolTipText = "uxAddContact";
            this.uxAddContact.Click += new System.EventHandler(this.uxAddContact_Click);
            // 
            // uxEndChat
            // 
            this.uxEndChat.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.uxEndChat.Image = ((System.Drawing.Image)(resources.GetObject("uxEndChat.Image")));
            this.uxEndChat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxEndChat.Name = "uxEndChat";
            this.uxEndChat.Size = new System.Drawing.Size(92, 24);
            this.uxEndChat.Text = "End Chat";
            this.uxEndChat.Click += new System.EventHandler(this.uxEndChat_Click);
            // 
            // uxListView
            // 
            this.uxListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.uxListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.uxNameCol,
            this.uxStatus});
            this.uxListView.Location = new System.Drawing.Point(12, 38);
            this.uxListView.Name = "uxListView";
            this.uxListView.Size = new System.Drawing.Size(369, 310);
            this.uxListView.TabIndex = 8;
            this.uxListView.UseCompatibleStateImageBehavior = false;
            this.uxListView.View = System.Windows.Forms.View.Details;
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
            // uxSend
            // 
            this.uxSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxSend.Location = new System.Drawing.Point(537, 310);
            this.uxSend.Name = "uxSend";
            this.uxSend.Size = new System.Drawing.Size(326, 38);
            this.uxSend.TabIndex = 11;
            this.uxSend.Text = "Send";
            this.uxSend.UseVisualStyleBackColor = true;
            this.uxSend.Click += new System.EventHandler(this.uxSend_Click);
            // 
            // ChatForm
            // 
            this.AcceptButton = this.uxSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 360);
            this.Controls.Add(this.uxSend);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.uxListView);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.uxMessageTextBox);
            this.Controls.Add(this.uxMessageListBox);
            this.MinimumSize = new System.Drawing.Size(968, 407);
            this.Name = "ChatForm";
            this.Text = "ChatForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.TextBox uxMessageTextBox;
        private System.Windows.Forms.ListBox uxMessageListBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton uxAddContact;
        private System.Windows.Forms.ToolStripButton uxEndChat;
        private System.Windows.Forms.ListView uxListView;
        private System.Windows.Forms.ColumnHeader uxNameCol;
        private System.Windows.Forms.ColumnHeader uxStatus;
        private System.Windows.Forms.Button uxSend;
    }
}