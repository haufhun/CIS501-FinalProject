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
    public class ChatRoom : IChatRoom
    {
        /// <summary>
        /// The List of text messages to keep track of the messages that have been sent in this chat room
        /// </summary>
        [JsonProperty]
        private List<TextMessage> _messages;

        /// <summary>
        /// The list that keeps thrack of the contacts that need to be added
        /// </summary>
        [JsonProperty]
        private ContactList _contactsToAdd;

        /// <summary>
        /// The Id associated with this ChatRoom. It can be referenced from outside.
        /// </summary>
        [JsonProperty]
        public string Id { get; }

        /// <summary>
        /// The Dictionary to store the users in this ChatRoom.
        /// </summary>
        [JsonProperty]
        private Dictionary<string, User> _users;

        /// <summary>
        /// The public property that refers to _contactsToAdd
        /// </summary>
        public IContactList ContactsToAdd => _contactsToAdd;

        /// <summary>
        /// The public property that refers to _messages
        /// </summary>
        public IEnumerable<ITextMessage> MessageHistory => _messages;

        /// <summary>
        /// The public property that refers to the values in _users
        /// </summary>
        public IEnumerable<IUser> Participants => _users.Values;

        /// <summary>
        /// Used for Json.
        /// </summary>
        /// <param name="msgs">The messages in this room</param>
        /// <param name="id">The id associated with this room</param>
        /// <param name="users">The Dictionary of users contained in this room</param>
        /// <param name="c">The list of contacts to add to the room</param>
        [JsonConstructor]
        private ChatRoom(List<TextMessage> msgs, string id, Dictionary<string, User> users, ContactList c)
        {
            _messages = msgs;
            Id = id;
            _users = users;
            _contactsToAdd = c;
        }

        /// <summary>
        /// Used only for simulating the client.
        /// </summary>
        /// <param name="id">The id of the room.</param>
        public ChatRoom(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Constructs a new ChatRoom. The client will set the id to null.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user1">Participant one.</param>
        /// <param name="user2">Participant two.</param>
        public ChatRoom(string id, User user1, User user2)
        {
            Id = id;
            _messages = new List<TextMessage>();
            _users = new Dictionary<string, User>
            {
                {user1.ContactInfo.Username, user1},
                {user2.ContactInfo.Username, user2}
            };
            _contactsToAdd = new ContactList();
        }

        /// <summary>
        /// Adds a user to this ChatRoom's dictionary of users.
        /// </summary>
        /// <param name="u">The user to be added</param>
        public void AddParticipant(User u)
        {
            _users.Add(u.ContactInfo.Username, u);
        }

        /// <summary>
        /// For the server alone. In order to add a message to a chat room.
        /// </summary>
        /// <param name="message">The message</param>
        public void AddMessage(TextMessage message)
        {
            _messages.Add(message);
        }

        /// <summary>
        /// Returns only the participants in this ChatRoom that are online.
        /// </summary>
        /// <returns>The online users</returns>
        public IEnumerable<User> GetOnlineParticipants()
        {
            return _users.Values.Where(u => u.ContactInfo.OnlineStatus == Status.Online).ToList();
        }

        /// <summary>
        /// Returns only the participants in this ChatRoom who are offline.
        /// </summary>
        /// <returns>The offline users</returns>
        public List<User> GetOfflineParticipants()
        {
            return _users.Values.Where(u => u.ContactInfo.OnlineStatus == Status.Offline).ToList();
        }

        /// <summary>
        /// Removes a user from the contacts to add to the ChatRoom.
        /// </summary>
        /// <param name="user">The user to be removed</param>
        public void RemoveContact(string user)
        {
            _contactsToAdd.Remove(user);
        }
    }
}
