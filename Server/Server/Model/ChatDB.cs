using System;
using System.Collections.Generic;
using Chat_CSLibrary;

namespace Server.Model
{
    public class ChatDb
    {
        private Dictionary<string, IUser> _users;
        private Dictionary<string, ChatRoom> _chatRooms;

        public ChatDb()
        {
            _users = new Dictionary<string, IUser>();
            _chatRooms = new Dictionary<string, ChatRoom>();
        }

        public ChatDb(Dictionary<string, IUser> users, Dictionary<string, ChatRoom> chatRooms)
        {
            //overload for JSON initializations
        }

        public ChatRoom LookupRoom(string id)
        {
            if (_chatRooms.ContainsKey(id))
            {
                return _chatRooms[id];
            }
            return null;
        }

        public User LookupUser(string username)
        {

            throw new NotImplementedException();
        }

        public bool ValidatePassword(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(string username, string password)
        {

        }

    }
}
