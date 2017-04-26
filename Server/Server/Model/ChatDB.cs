﻿using System;
using System.Collections.Generic;
using Chat_CSLibrary;

namespace Server.Model
{
    public class ChatDb
    {
        private Dictionary<string, User> _users;
        private Dictionary<string, ChatRoom> _chatRooms;

        public IEnumerable<User> Users => _users.Values;

        public ChatDb()
        {
            _users = new Dictionary<string, User>();
            _chatRooms = new Dictionary<string, ChatRoom>();
        }

        public ChatDb(Dictionary<string, User> users, Dictionary<string, ChatRoom> chatRooms)
        {
            //overload for JSON initializations
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
