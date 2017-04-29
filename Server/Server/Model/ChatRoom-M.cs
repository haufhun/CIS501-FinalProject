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
        [JsonProperty]
        private List<TextMessage> _messages;

        [JsonProperty]
        //We want this to be a JsonProperty so that when the client gives the server a ChatRoom, we know which one to associate it with...
        public string Id { get; }

        [JsonProperty]
        private Dictionary<string, User> _users;

        public IEnumerable<ITextMessage> MessageHistory => _messages;

        public IEnumerable<IUser> Participants => _users.Values;

        /// <summary>
        /// Used for Json.
        /// </summary>
        /// <param name="msgs"></param>
        /// <param name="id"></param>
        /// <param name="users"></param>
        [JsonConstructor]
        private ChatRoom(List<TextMessage> msgs, string id, Dictionary<string, User> users)
        {
            _messages = msgs;
            Id = id;
            _users = users;
        }

        /// <summary>
        /// Used only for simulating the client.
        /// </summary>
        /// <param name="id">The id.</param>
        public ChatRoom(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Constructs a new ChatRoom. The client will set the id to null.
        /// </summary>
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
        }

        public void AddParticipant(User u)
        {
            _users.Add(u.ContactInfo.Username, u);
        }

        /// <summary>
        /// For the server alone. In order to add a message to a chat room.
        /// </summary>
        /// <param name="message"></param>
        public void AddMessage(TextMessage message)
        {
            _messages.Add(message);
        }

        public IEnumerable<User> GetOnlineParticipants()
        {
            var s = new List<User>();

            foreach (var u in _users.Values)
            {
                if (u.ContactInfo.OnlineStatus == Status.Online)
                {
                    s.Add(u);
                }
            }

            return s;
        }

        public List<User> GetOfflineParticipants()
        {
            //Find all the users that have a status of offline. only for the server.
            var s = new List<User>();

            foreach (var u in _users.Values)
            {
                if(u.ContactInfo.OnlineStatus == Status.Offline)
                {
                    s.Add(u);
                }
            }

            return s;
        }
    }
}
