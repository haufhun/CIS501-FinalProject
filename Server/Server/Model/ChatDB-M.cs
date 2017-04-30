using System;
using System.Collections.Generic;
using Chat_CSLibrary;
using Newtonsoft.Json;

namespace Server.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ChatDb
    {
        [JsonProperty]
        private Dictionary<string, User> _users;
        private Dictionary<string, ChatRoom> _chatRooms;
        private string _nextRoomPos;

        public IEnumerable<User> Users => _users.Values;

        public IEnumerable<ChatRoom> ChatRooms => _chatRooms.Values;

        public ChatDb()
        {
            _users = new Dictionary<string, User>();
            _chatRooms = new Dictionary<string, ChatRoom>();
            _nextRoomPos = "0";
        }

        public ChatDb(Dictionary<string, User> users, Dictionary<string, ChatRoom> chatRooms)
        {
            //overload for JSON initializations
        }

        public ChatRoom CreateRoom(User u1, User u2)
        {
            var cr = new ChatRoom(_nextRoomPos, u1, u2);
            _chatRooms.Add(_nextRoomPos, cr);
            _nextRoomPos = (Convert.ToInt32(_nextRoomPos) + 1).ToString();

            return cr;
        }
        public ChatRoom LookupRoom(string id)
        {
            return _chatRooms.ContainsKey(id) ? _chatRooms[id] : null;
        }

        public User LookupUser(string username)
        {
            return _users.ContainsKey(username) ? _users[username] : null;
        }

        public void CreateUser(string username, string password)
        {

        }

        public void AddUser(string username, string password, string sessionId)
        {
            var u = new User(new Contact(username, Status.Online), password, sessionId);
            _users.Add(username, u);
        }
    }
}
