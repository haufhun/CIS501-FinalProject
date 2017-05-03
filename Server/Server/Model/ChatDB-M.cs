using System;
using System.Collections.Generic;
using Chat_CSLibrary;
using Newtonsoft.Json;

namespace Server.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ChatDb
    {
        /// <summary>
        /// The dictionary that stores the users
        /// </summary>
        [JsonProperty]
        private Dictionary<string, User> _users;

        /// <summary>
        /// The dictionary that stores the chatrooms
        /// </summary>
        private Dictionary<string, ChatRoom> _chatRooms;

        /// <summary>
        /// Keeps track of the id to give the next chatroom.
        /// </summary>
        private string _nextRoomPos;

        /// <summary>
        /// A referencable property that refers to the values of users in _users
        /// </summary>
        public IEnumerable<User> Users => _users.Values;

        /// <summary>
        /// The referencable property that refers to the chatrooms stored in _chatrooms
        /// </summary>
        public IEnumerable<ChatRoom> ChatRooms => _chatRooms.Values;

        /// <summary>
        /// The constructor that initializes the private fields
        /// </summary>
        public ChatDb()
        {
            _users = new Dictionary<string, User>();
            _chatRooms = new Dictionary<string, ChatRoom>();
            _nextRoomPos = "0";
        }

        /// <summary>
        /// Used only for Json.
        /// </summary>
        /// <param name="users"></param>
        [JsonConstructor]
        private ChatDb(Dictionary<string, User> users)
        {
            _users = users;
            _chatRooms = new Dictionary<string, ChatRoom>();
            _nextRoomPos = "0";
        }

        /// <summary>
        /// Overload
        /// </summary>
        /// <param name="users"></param>
        /// <param name="chatRooms"></param>
        public ChatDb(Dictionary<string, User> users, Dictionary<string, ChatRoom> chatRooms)
        {
            //overload for JSON initializations
        }

        /// <summary>
        /// Creates a chat room with the two users, adds it to _chatRooms, and returns it
        /// </summary>
        /// <param name="u1">The first user for the chat room</param>
        /// <param name="u2">The second user for the chat room</param>
        /// <returns>The room that was created</returns>
        public ChatRoom CreateRoom(User u1, User u2)
        {
            var cr = new ChatRoom(_nextRoomPos, u1, u2);
            _chatRooms.Add(_nextRoomPos, cr);
            _nextRoomPos = (Convert.ToInt32(_nextRoomPos) + 1).ToString();

            return cr;
        }

        /// <summary>
        /// Looks up a room with the given id and returns it, returns null if it doesn't exist
        /// </summary>
        /// <param name="id">The id of the room to be searched</param>
        /// <returns>The room associated with the id if it exists, otherwise null</returns>
        public ChatRoom LookupRoom(string id)
        {
            return _chatRooms.ContainsKey(id) ? _chatRooms[id] : null;
        }

        /// <summary>
        /// Looks up a user associated with the given username and returns it if ite exists, otherwise null.
        /// </summary>
        /// <param name="username">The name of the  user to be searched</param>
        /// <returns>The user if it exists, otherwise null</returns>
        public User LookupUser(string username)
        {
            return _users.ContainsKey(username) ? _users[username] : null;
        }

        /// <summary>
        /// Adds a user with the given username, password, and sessionId to _users
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <param name="sessionId">The sessionId</param>
        public void AddUser(string username, string password, string sessionId)
        {
            var u = new User(new Contact(username, Status.Online), password, sessionId);
            _users.Add(username, u);
        }

        /// <summary>
        /// Removes the chat room from the dictionary of Chat Rooms.
        /// </summary>
        /// <param name="chatId">The id of the chat room to be removed.</param>
        public void RemoveRoom(string chatId)
        {
            _chatRooms.Remove(chatId);
        }
    }
}
