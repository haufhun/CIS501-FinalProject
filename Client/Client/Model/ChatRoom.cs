using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat_CSLibrary;
using Newtonsoft.Json;

namespace Client.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ChatRoom : IChatRoom
    {
        //[JsonProperty]
        //private List<TextMessage> _messages;

        //[JsonProperty]
        ////We want this to be a JsonProperty so that when the client gives the server a ChatRoom, we know which one to associate it with...
        //public string Id { get; }

        //public IEnumerable<ITextMessage> MessageHistory => _messages;

        //public IEnumerable<IUser> Participants => _users.Values;

        //private Dictionary<string, User> _users;



        ///// <summary>
        ///// Used for Json.
        ///// </summary>
        ///// <param name="msgs"></param>
        ///// <param name="list"></param>
        //private ChatRoom(List<TextMessage> msgs, string id)
        //{
        //    _messages = msgs;
        //    Id = id;
        //}
        [JsonProperty]
        //Private field storing a List of messages
        private List<TextMessage> _messages;

        [JsonProperty]
        //Private field for a ContactList object storing contacts to add
        private ContactList _contactsToAdd;

        [JsonProperty]
        //We want this to be a JsonProperty so that when the client gives the server a ChatRoom, we know which one to associate it with...
        public string Id { get; }

        [JsonProperty]
        //Private field for dictionary which stores users
        private Dictionary<string, User> _users;

        //Getter for contacts to add
        public IContactList ContactsToAdd => _contactsToAdd;

        //Getter for message history
        public IEnumerable<ITextMessage> MessageHistory => _messages;

        //Getter for participants
        public IEnumerable<IUser> Participants => _users.Values;


        /// <summary>
        /// Used for Json.
        /// </summary>
        /// <param name="msgs">List of messages being passed in</param>
        /// <param name="id">ID passed in for Chatroom</param>
        /// <param name="users">Dictionary holding users passed in</param>
        /// <param name="c">ContactList object passed in</param>
        [JsonConstructor]
        private ChatRoom(List<TextMessage> msgs, string id, Dictionary<string, User> users, ContactList c)
        {
            _messages = msgs;
            Id = id;
            _users = users;
            _contactsToAdd = c;
        }

        /// <summary>
        /// Default constructor that creates a new chat room. The client will set the id to null, but the server will set it to a unique id.
        /// </summary>
        /// <param name="id">The unique id associated with this chat room. Null if the client constructed it.</param>
        public ChatRoom(string id)
        {
            Id = id;
        }

        /// <summary>
        /// For the server alone. In order to add a message to a chat room.
        /// </summary>
        /// <param name="message">Message passed in</param>
        public void AddMessage(TextMessage message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method gets the offline participants 
        /// </summary>
        public IEnumerable<IContact> GetOfflineParticipants()
        {
            //Find all the users that have a status of offline. only for the server.
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method handles updating the Contact List status
        /// </summary>
        /// <param name="s">The status being passed in</param>
        public void UpdateContactListStatus(Status s)
        {
            foreach (var contact in _contactsToAdd.Contacts)
            {
               var c = (Contact) contact;
                c.ChangeOnlineStatus(s);
            }
        }

        public TextMessage TextMessage
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}
