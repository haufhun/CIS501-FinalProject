using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.View;

namespace Client
{
    public partial class SignInForm : Form
    {
        private HomeForm _homeForm;
        private SignInHandler _sIHandler;

        public SignInForm(SignInHandler s, HomeForm homeForm)
        {
            _sIHandler = s;
            this._homeForm = homeForm;
            InitializeComponent();
        }


        private void uxSignIn_Click(object sender, EventArgs e)
        {       
            _sIHandler(uxUsernameTxt.Text, uxPassTxt.Text);
        }

        public void EventSuccessfulLogin()
        {
            _homeForm.Invoke(new MethodInvoker(_homeForm.Show));
            this.Invoke(new MethodInvoker(this.Hide));
        }
        public void EventUnSuccessfulLogin()
        {
            //_homeForm.Invoke(new MethodInvoker(_homeForm.Show));
            //this.Invoke(new MethodInvoker(this.Hide));
        }
        public void SignOut()
        {
            this.Invoke(new MethodInvoker(this.Show));
        }
    }

}
