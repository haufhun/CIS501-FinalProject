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
        int NumberOfParticipants();
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class ChatRoom : IChatRoom
    {
        [JsonProperty]
        private List<TextMessage> _messages;

        private Dictionary<string, User> _users;

        [JsonProperty]
        public IContactList Participants { get; private set; }
        

        public string Id { get; }

        public ChatRoom(string id)
        {
            Id = id;
        }

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

        //Do we want this to be Enumerable of TextMessage? I think soo.....
        public IEnumerable<ITextMessage> GetMessageHistory()
        {
            throw new NotImplementedException();
        }

        public int NumberOfParticipants()
        {
            throw new NotImplementedException();
        }

    }
}
