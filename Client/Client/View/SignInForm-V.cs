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
        private HomeForm homeForm;
        private SignInHandler _sIHandler;

        public SignInForm(SignInHandler s, HomeForm homeForm)
        {
            _sIHandler = s;
            this.homeForm = homeForm;
            InitializeComponent();
        }


        private void uxSignIn_Click(object sender, EventArgs e)
        {       
            _sIHandler(uxUsernameTxt.Text, uxPassTxt.Text);
        }

        public void EventSuccessfulLogin()
        {
            //homeForm.Show();
            Application.Run(homeForm);
            
           // Hide();
        }
    }

}
