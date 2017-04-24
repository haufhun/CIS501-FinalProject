using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Server.Model
{
    public interface IChatRoom
    {
        string Id { get; }
        IEnumerable<ITextMessage> GetMessageHistory();
        IContactList Participants { get; }
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class ChatRoom : IChatRoom
    {
        [JsonProperty]
        private List<TextMessage> _messages;

        [JsonProperty]
        //We want this to be a JsonProperty so that when the client gives the server a ChatRoom, we know which one to associate it with...
        public string Id { get; }

        [JsonProperty]
        public IContactList Participants { get; private set; }

        private Dictionary<string, User> _users;
        
        /// <summary>
        /// Used for Json.
        /// </summary>
        /// <param name="msgs"></param>
        /// <param name="list"></param>
        private ChatRoom(List<TextMessage> msgs, ContactList list)
        {
            _messages = msgs;
            Participants = list;
        }

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

        //Do we want this to be IEnumerable of TextMessage? I think soo.....
        public IEnumerable<ITextMessage> GetMessageHistory()
        {
            return _messages; //Does this work??? 
            throw new NotImplementedException();
        }

        public List<IContact> GetOfflineParticipants()
        {
            //Find all the users that have a status of offline. only for the server.
            throw new NotImplementedException();
        }
    }
}
