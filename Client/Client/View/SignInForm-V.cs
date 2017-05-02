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
        //
        private HomeForm _homeForm;
        //
        private SignInHandler _sIHandler;
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="homeForm"></param>
        /// <param name="chatDb"></param>
        public SignInForm(SignInHandler s, HomeForm homeForm)
        {
            _sIHandler = s;
            this._homeForm = homeForm;

            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSignIn_Click(object sender, EventArgs e)
        {       
            _sIHandler(uxUsernameTxt.Text, uxPassTxt.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        public void EventSuccessfulLogin()
        {
            _homeForm.Invoke(new MethodInvoker(_homeForm.Show));
            this.Invoke(new MethodInvoker(this.Hide));
        }

        /// <summary>
        /// 
        /// </summary>
        public void EventUnSuccessfulLogin()
        {
            MessageBox.Show("Incorrect username or password. Please try again.");
            //_homeForm.Invoke(new MethodInvoker(_homeForm.Show));
            //this.Invoke(new MethodInvoker(this.Hide));
        }

        /// <summary>
        /// 
        /// </summary>
        public void SignOut()
        {
            this.Invoke(new MethodInvoker(this.Show));
        }
    }

}
