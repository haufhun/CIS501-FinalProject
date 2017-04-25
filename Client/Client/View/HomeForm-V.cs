using System.Windows.Forms;

namespace Client.View
{
    public partial class HomeForm : Form
    {
        private SignInHandler _sIHandler;
        private AddContactHandler _addCHandler;
        private RemoveContactHandler _removeCHandler;
        private AddContactToRoomHandler _addCToRoomHandler;
        private CreateRoomHandler _createRoomHandler;

        public HomeForm(SignInHandler s, AddContactHandler ac, RemoveContactHandler rc, AddContactToRoomHandler acr, CreateRoomHandler cr)
        {
            _sIHandler = s;
            _addCHandler = ac;
            _removeCHandler = rc;
            _addCToRoomHandler = acr;
            _createRoomHandler = cr;

            InitializeComponent();
        }

        private void uxSignOut_Click(object sender, System.EventArgs e)
        {
            
            Hide();
           // SignInForm s = new SignInForm();                                                                                                                                                  

        }
    }
}
