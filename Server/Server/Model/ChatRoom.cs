using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat_CSLibrary;

namespace Server.Model
{
    public class ChatRoom : IChatRoom
    {
        private List<string> _messages;

        private Dictionary<string, User> _users;

        public ChatRoom()
        {
            _messages = new List<string>();
            _users = new Dictionary<string, User>();
        }

        public List<string> MessageHistory => _messages;

        public string Id { get; }

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
