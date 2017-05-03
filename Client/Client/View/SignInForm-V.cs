using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Model;
using Client.View;

namespace Client
{
    public partial class SignInForm : Form
    {
        //private field for accessing the homeform
        private HomeForm _homeForm;
        //privaate field for accessing the sign in handler
        private SignInHandler _sIHandler;

        /// <summary>
        /// The handler for the button press for the signIn button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSignIn_Click(object sender, EventArgs e)
        {
            _sIHandler(uxUsernameTxt.Text, uxPassTxt.Text);
        }

        /// <summary>
        /// This method initializes the sign in form
        /// </summary>
        /// <param name="s">Handler for the signIn passed in</param>
        /// <param name="homeForm">Homeform object passed in</param>
        public SignInForm(SignInHandler s, HomeForm homeForm)
        {
            _sIHandler = s;
            this._homeForm = homeForm;

            InitializeComponent();
        }

        /// <summary>
        /// This handles the View side of a successful login
        /// </summary>
        public void EventSuccessfulLogin()
        {
            _homeForm.Invoke(new MethodInvoker(_homeForm.Show));
            this.Invoke(new MethodInvoker(this.Hide));
        }

        /// <summary>
        /// This handles the View side of an unsuccessful login
        /// </summary>
        public void EventUnSuccessfulLogin()
        {
            MessageBox.Show("Incorrect username or password. Please try again.");
        }

        /// <summary>
        /// This method handles what happens with SignOut in the view
        /// </summary>
        public void SignOut()
        {
            this.Invoke(new MethodInvoker(this.Show));
            this.Invoke(new MethodInvoker(delegate{ this.uxPassTxt.Text = "";}));
        }

        /// <summary>
        /// This is the event handler for the exit button. Closes the program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}
