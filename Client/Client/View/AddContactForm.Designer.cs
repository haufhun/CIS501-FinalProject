namespace Client.View
{
    partial class AddContactForm
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
            this.uxAdd = new System.Windows.Forms.Button();
            this.uxInfoTxt = new System.Windows.Forms.TextBox();
            this.uxInfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uxAdd
            // 
            this.uxAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uxAdd.Location = new System.Drawing.Point(99, 88);
            this.uxAdd.Name = "uxAdd";
            this.uxAdd.Size = new System.Drawing.Size(103, 42);
            this.uxAdd.TabIndex = 9;
            this.uxAdd.Text = "Add";
            this.uxAdd.UseVisualStyleBackColor = true;
            this.uxAdd.Visible = false;
            // 
            // uxInfoTxt
            // 
            this.uxInfoTxt.Location = new System.Drawing.Point(20, 50);
            this.uxInfoTxt.Name = "uxInfoTxt";
            this.uxInfoTxt.Size = new System.Drawing.Size(261, 22);
            this.uxInfoTxt.TabIndex = 8;
            this.uxInfoTxt.Visible = false;
            // 
            // uxInfoLabel
            // 
            this.uxInfoLabel.AutoSize = true;
            this.uxInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxInfoLabel.Location = new System.Drawing.Point(17, 17);
            this.uxInfoLabel.Name = "uxInfoLabel";
            this.uxInfoLabel.Size = new System.Drawing.Size(274, 20);
            this.uxInfoLabel.TabIndex = 7;
            this.uxInfoLabel.Text = "Please enter a contact name to add";
            this.uxInfoLabel.Visible = false;
            // 
            // AddContactForm
            // 
            this.AcceptButton = this.uxAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 152);
            this.Controls.Add(this.uxAdd);
            this.Controls.Add(this.uxInfoTxt);
            this.Controls.Add(this.uxInfoLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AddContactForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Contact";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label uxInfoLabel;
        public System.Windows.Forms.TextBox uxInfoTxt;
        public System.Windows.Forms.Button uxAdd;
    }
}