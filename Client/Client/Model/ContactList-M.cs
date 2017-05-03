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
    public class ContactList : IContactList
    {
        [JsonProperty]
        //This is the private field for the Dictionary holding the contacts
        private Dictionary<string, Contact> _contacts;

        //This is the getter for the count of contacts
        public int Count => _contacts.Values.Count;

        //This is the getter for the contacts values
        public IEnumerable<IContact> Contacts => _contacts.Values; // had to add to iplement Icontact

        /// <summary>
        /// This initializes the ContactList to a Dictionary
        /// </summary>
        public ContactList()
        {
            _contacts = new Dictionary<string, Contact>();
        }

        /// <summary>
        /// This initializes the ContactList to the private field _contacts
        /// </summary>
        /// <param name="contacts">Dictionary of contacts passed in/param>
        [JsonConstructor]
        private ContactList(Dictionary<string, Contact> contacts)
        {
            _contacts = contacts;
        }

        public void RemoveContact(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IContact> GetAllContacts()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This gets the contacts
        /// </summary>
        /// <param name="username">Username for the Contact</param>
        /// <returns>The contact info for that username</returns>
        public IContact GetContact(string username)
        {
            return _contacts[username];
        }

    }
    //class ContactList_M
    //{
    //    private Dictionary<string, Contact> _contacts = new Dictionary<string, Contact>();

    //    void AddContact(string name)
    //    {

    //    }

    //    void RemoveContact(string name)
    //    {

    //    }

    //    public void UpdateForm()
    //    {

    //    }
    //}
}
