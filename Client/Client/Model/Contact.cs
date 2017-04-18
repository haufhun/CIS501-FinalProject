using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Contact
    {
        private string _name;
        private bool _status;

        public Contact(string name)
        {
            _name = name;
            _status = false;
        }
        public string GetName
        {
            get { return _name; }
        }
        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}
