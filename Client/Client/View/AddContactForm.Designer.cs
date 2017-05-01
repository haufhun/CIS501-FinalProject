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
            this.uxTxt = new System.Windows.Forms.TextBox();
            this.uxAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uxTxt
            // 
            this.uxTxt.Location = new System.Drawing.Point(27, 86);
            this.uxTxt.Name = "uxTxt";
            this.uxTxt.Size = new System.Drawing.Size(270, 22);
            this.uxTxt.TabIndex = 2;
            // 
            // uxAdd
            // 
            this.uxAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uxAdd.Location = new System.Drawing.Point(104, 133);
            this.uxAdd.Name = "uxAdd";
            this.uxAdd.Size = new System.Drawing.Size(114, 56);
            this.uxAdd.TabIndex = 1;
            this.uxAdd.Text = "Add";
            this.uxAdd.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please enter a contact name to add";
            // 
            // AddContactForm
            // 
            this.AcceptButton = this.uxAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 211);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxTxt);
            this.Controls.Add(this.uxAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddContactForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Contact";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button uxAdd;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox uxTxt;
    }
}