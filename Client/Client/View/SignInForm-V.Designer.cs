﻿namespace Client
{
    partial class SignInForm
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
            this.uxUsernameTxt = new System.Windows.Forms.TextBox();
            this.uxPassTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uxSignIn = new System.Windows.Forms.Button();
            this.uxInfoLabel = new System.Windows.Forms.Label();
            this.uxExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxUsernameTxt
            // 
            this.uxUsernameTxt.Location = new System.Drawing.Point(27, 89);
            this.uxUsernameTxt.Name = "uxUsernameTxt";
            this.uxUsernameTxt.Size = new System.Drawing.Size(207, 22);
            this.uxUsernameTxt.TabIndex = 0;
            // 
            // uxPassTxt
            // 
            this.uxPassTxt.Location = new System.Drawing.Point(27, 165);
            this.uxPassTxt.Name = "uxPassTxt";
            this.uxPassTxt.PasswordChar = '*';
            this.uxPassTxt.Size = new System.Drawing.Size(207, 22);
            this.uxPassTxt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // uxSignIn
            // 
            this.uxSignIn.Location = new System.Drawing.Point(27, 219);
            this.uxSignIn.Name = "uxSignIn";
            this.uxSignIn.Size = new System.Drawing.Size(97, 49);
            this.uxSignIn.TabIndex = 4;
            this.uxSignIn.Text = "Sign In";
            this.uxSignIn.UseVisualStyleBackColor = true;
            this.uxSignIn.Click += new System.EventHandler(this.uxSignIn_Click);
            // 
            // uxInfoLabel
            // 
            this.uxInfoLabel.AutoSize = true;
            this.uxInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxInfoLabel.Location = new System.Drawing.Point(22, 9);
            this.uxInfoLabel.Name = "uxInfoLabel";
            this.uxInfoLabel.Size = new System.Drawing.Size(138, 25);
            this.uxInfoLabel.TabIndex = 5;
            this.uxInfoLabel.Text = "Please Sign In";
            // 
            // uxExit
            // 
            this.uxExit.Location = new System.Drawing.Point(137, 219);
            this.uxExit.Name = "uxExit";
            this.uxExit.Size = new System.Drawing.Size(97, 49);
            this.uxExit.TabIndex = 6;
            this.uxExit.Text = "Exit";
            this.uxExit.UseVisualStyleBackColor = true;
            this.uxExit.Click += new System.EventHandler(this.uxExit_Click);
            // 
            // SignInForm
            // 
            this.AcceptButton = this.uxSignIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 286);
            this.Controls.Add(this.uxExit);
            this.Controls.Add(this.uxInfoLabel);
            this.Controls.Add(this.uxSignIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxPassTxt);
            this.Controls.Add(this.uxUsernameTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SignInForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uxUsernameTxt;
        private System.Windows.Forms.TextBox uxPassTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button uxSignIn;
        private System.Windows.Forms.Label uxInfoLabel;
        private System.Windows.Forms.Button uxExit;
    }
}