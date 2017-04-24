using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class ClientController_C
    {
        private SignInFormObserver _sIFormObserver;

        private List<HomeFormObserver> _hFormObserver = new List<HomeFormObserver>();

        private List<ChatFormObserver> _cFormObserver = new List<ChatFormObserver>();

        public void SignInRegister(SignInFormObserver o)
        {
            _sIFormObserver = o;
        }
        public void HomeFormRegister(HomeFormObserver o)
        {
            _hFormObserver.Add(o);
        }
        public void ChatFormRegister(ChatFormObserver o)
        {
            _cFormObserver.Add(o);
        }
       
        

        public void SignIn(string name, string password)
        {
            
        }

        public void AddContact(string name)
        {
            
        }

        public void RemoveContact(string name)
        {
            
        }

        public void AddContactToRoom(string name)
        {
            
        }

        public void CreateRoom()
        {
            
        }
        private void SignalCFormObserver()
        {

        }
        private void SignalHFormObserver()
        {
            
        }

        private void SignalSIFormObsever()
        {
            
        }

        
    }

}
