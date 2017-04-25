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
        [JsonProperty]
        private List<TextMessage> _messages;

        [JsonProperty]
        //We want this to be a JsonProperty so that when the client gives the server a ChatRoom, we know which one to associate it with...
        public string Id { get; }

        public IEnumerable<ITextMessage> MessageHistory => _messages;

        public IEnumerable<IUser> Participants => _users.Values;

        private Dictionary<string, User> _users;

        /// <summary>
        /// Used for Json.
        /// </summary>
        /// <param name="msgs"></param>
        /// <param name="list"></param>
        private ChatRoom(List<TextMessage> msgs, string id)
        {
            _messages = msgs;
            Id = id;
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
        /// <param name="message"></param>
        public void AddMessage(TextMessage message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IContact> GetOfflineParticipants()
        {
            //Find all the users that have a status of offline. only for the server.
            throw new NotImplementedException();
        }
    }
}
