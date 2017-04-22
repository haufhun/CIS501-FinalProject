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

        private Dictionary<string, IUser> _users;

        public ChatRoom()
        {
            _messages = new List<string>();
            _users = new Dictionary<string, IUser>();
        }

        public List<string> MessageHistory => _messages;

        public string Id { get; }

        public int NumberOfPartcipants()
        {
            return _users.Count;
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            return _users.Values;
        }

        public void RemoveUser(string username)
        {
            
        }

    }
}
