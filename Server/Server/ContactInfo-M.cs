using System;
using System.Collections.Generic;

namespace Chat_CSLibrary
{
    public class ContactList : IContactList
    {
        private Dictionary<string, IContact> _contacts;

        public ContactList()
        {
            _contacts = new Dictionary<string, IContact>();
        }
        public void AddContact(string name)
        {
            throw new NotImplementedException();
        }

        public void RemoveContact(string name)
        {
            throw new NotImplementedException();
        }

        public IContact GetContact(string username)
        {
            throw new NotImplementedException();
        }

        public List<IContact> GetAllContacts()
        {
            throw new NotImplementedException();
        }
    }

    public class Contact : IContact
    {
        public bool Status { get; set; }
        public string Username { get; set; }
    }

    public class M
    {
        public IContactList c = new ContactList();

        public void m()
        {
        }
    }
}
