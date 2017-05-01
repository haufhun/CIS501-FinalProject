using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Chat_CSLibrary;

namespace Client.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class User : IUser
    {
        [JsonProperty]
        private string _password;

        [JsonProperty]
        private ContactList _contactList;

        [JsonProperty]
        private Contact _contact;


        //
        public IContact ContactInfo => _contact;
        //
        public IContactList ContactList => _contactList;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="contactInfo"></param>
        /// <param name="contactList"></param>
        [JsonConstructor]
        private User(string password, Contact contactInfo, ContactList contactList)
        {
            _password = password;
            _contact = contactInfo;
            _contactList = contactList;
        }

        public ContactList MyContactList { get; set; }
        public Contact MyContact { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public User(string username, string password)
        {
            _password = password;
            _contact = new Contact(username);
            _contactList = new ContactList();
        }

       /* public User()
        {
            MyContactList = new ContactList();
            MyContact = new Contact(null);
        }*/

        public Dictionary<string, Contact> GetAllContacts()
        {
            var cL = (ContactList)ContactList;
            //return cL.GetAllContacts;
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        public void AddContact(Contact c)
        {
            if(ContactList == null)
                _contactList = new ContactList();
            var cL = (ContactList)ContactList;
            cL.AddContact(c);
            _contactList = cL;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        public void RemoveContact(Contact c)
        {
            var cL = (ContactList)ContactList;
            cL.RemoveContact(c);
            _contactList = cL;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newStatus"></param>
        public void ChangeStatus(Status newStatus)
        {
            throw new NotImplementedException();
        }

    }
}
