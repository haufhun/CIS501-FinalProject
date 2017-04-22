using System;
using System.Collections.Generic;
using Chat_CSLibrary;

namespace Server.Model
{
    public class ContactList : IContactList
    {
        private Dictionary<string, Contact> _contacts;

        public ContactList()
        {
            _contacts = new Dictionary<string, Contact>();
        }
        public void AddContact(string name)
        {
            throw new NotImplementedException();
        }

        public void RemoveContact(string name)
        {
            throw new NotImplementedException();
        }


        /*
         * These two methods will be used by the Client. We don't really want to use them in the server.
         */
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
        private string _username;

        private Status _onlineStatus;


        public string Username => _username;

        Status IContact.OnlineStatus => _onlineStatus;

        public Contact(string username)
        {
            _username = username;
            _onlineStatus = Status.Online;
        }
    }
}
