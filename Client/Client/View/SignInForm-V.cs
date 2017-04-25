using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            _sIHandler("Tyler", "456");
        }
    }
}
