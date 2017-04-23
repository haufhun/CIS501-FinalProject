using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat_CSLibrary;
using Newtonsoft.Json;

namespace Server.Model
{
    [JsonObject]
    public class ChatRoom : IChatRoom
    {
        [JsonProperty]
        private List<string> _messages;
        [JsonProperty]
        private Dictionary<string, User> _users;
        public List<string> MessageHistory => _messages;
        public string Id { get; }

        public ChatRoom()
        {
            _messages = new List<string>();
            _messages.Add("HUnter: Hey what's up");
            _users = new Dictionary<string, User>();
            _users.Add("haufhun", new User(new Contact("haufhun"), "password"));
        }

        [JsonConstructor]
        public ChatRoom(List<string> msgs, Dictionary<string, User> users)
        {
            _messages = msgs;
            _users = users;
        }

        public int NumberOfPartcipants()
        {
            return _users.Count;
        }

        public IEnumerable<User> GetAllUsers()
        {
            List<User> list = new List<User>();
            foreach (User u in _users.Values)
            {
                list.Add(u);
            }
            return list;
        }

        public void RemoveUser(string username)
        {

        }
    }
}
