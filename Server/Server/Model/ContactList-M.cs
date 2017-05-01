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
        [JsonProperty]
        private Dictionary<string, Contact> _contacts;

        public int Count => _contacts.Values.Count;

        public IEnumerable<IContact> Contacts => _contacts.Values;

        public ContactList()
        {
            _contacts = new Dictionary<string, Contact>();
        }

        [JsonConstructor]
        private ContactList(Dictionary<string, Contact> contacts)
        {
            _contacts = contacts;
            //if (contacts == null)
            //{
            //    _contacts = new Dictionary<string, IContact>();
            //}
            //else
            //{
            //    var temp = new Dictionary<string, IContact>();
            //    foreach (var c in contacts.Values)
            //    {
            //        temp.Add(c.Username, c);
            //    }
            //    _contacts = temp;
            //}
        }

        public void Add(Contact c)
        {
            _contacts.Add(c.Username, c);
        }

        public void Remove(string username)
        {
            _contacts.Remove(username);
        }

        /// <summary>
        /// Returns the contact object of type IContact if the user exists. Otherwise, returns null.
        /// </summary>
        /// <param name="username">The name of the user to lookup.</param>
        /// <returns></returns>
        public IContact GetContact(string username)
        {
            return _contacts.ContainsKey(username) ? _contacts[username] : null;
        }

    }
}
