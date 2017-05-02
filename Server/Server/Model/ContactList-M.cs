using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Chat_CSLibrary;

namespace Server.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ContactList : IContactList
    {
        /// <summary>
        /// The Dictionary of Contacts that this class is built around. Values
        /// are Contacts, keys are the contacts' usernames.
        /// </summary>
        [JsonProperty]
        private Dictionary<string, Contact> _contacts;

        /// <summary>
        /// The number of contacts in _contacts
        /// </summary>
        public int Count => _contacts.Values.Count;

        /// <summary>
        /// The public field that keeps track of the values in _contacts as an IEnumerable
        /// </summary>
        public IEnumerable<IContact> Contacts => _contacts.Values;

        /// <summary>
        /// The Constructor. Simplly initializes _contacts
        /// </summary>
        public ContactList()
        {
            _contacts = new Dictionary<string, Contact>();
        }

        /// <summary>
        /// The Json Constructor for this class
        /// </summary>
        /// <param name="contacts">The dictionary of Contacts</param>
        [JsonConstructor]
        private ContactList(Dictionary<string, Contact> contacts)
        {
            _contacts = contacts;
        }

        /// <summary>
        /// Adds a contact to _contacts as long as that contact does not already exist.
        /// </summary>
        /// <param name="c">The Contact to add</param>
        /// <returns>True if the contact was added, false if it already exists</returns>
        public bool Add(Contact c)
        {
            if (_contacts.ContainsKey(c.Username))
                return false;

            _contacts.Add(c.Username, c);
            return true;
        }

        /// <summary>
        /// Removes a contact from _contacts.
        /// </summary>
        /// <param name="username">The name of the contact to be removed</param>
        public void Remove(string username)
        {
            _contacts.Remove(username);
        }

        /// <summary>
        /// Returns the contact object of type IContact if the user exists. Otherwise, returns null.
        /// </summary>
        /// <param name="username">The name of the user to lookup.</param>
        /// <returns>The contact if the user exists, otherwise null</returns>
        public IContact GetContact(string username)
        {
            return _contacts.ContainsKey(username) ? _contacts[username] : null;
        }

    }
}
