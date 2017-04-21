using System;
using System.Collections.Generic;
using Chat_CSLibrary;

namespace Server.Model
{
    public class ChatDb
    {
        private Dictionary<string, IUser> _users;
        private Dictionary<string, IChatRoom> _chatRooms;

        public ChatDb()
        {
            _users = new Dictionary<string, IUser>();
            _chatRooms = new Dictionary<string, IChatRoom>();
        }

        public ChatDb(Dictionary<string, IUser> users, Dictionary<string, IChatRoom> chatRooms)
        {
            //overload for JSON initializations
        }

        public IChatRoom LookupRoom(string id)
        {
            if (_chatRooms.ContainsKey(id))
            {
                return _chatRooms[id];
            }
            return null;
        }

        public bool LookupUser(string username)
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
