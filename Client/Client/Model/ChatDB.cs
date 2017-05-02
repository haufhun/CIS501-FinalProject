using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat_CSLibrary;
namespace Client.Model
{
    public class ChatDB
    {
        /// <summary>
        /// Holds the User information database.
        /// </summary>
        public ChatDB()
        {
            User = new User(null, null);
            ChatRooms = new Dictionary<string, ChatRoom>();

        }

        /// <summary>
        /// This gets and sets the User objects.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// This gets and sets the Chatroom and places it into a Dictionary. ContactList of chatroom. 
        /// </summary>
        public Dictionary<string, ChatRoom> ChatRooms { get; set; }

        //public ChatDB(Dictionary<string, User> users, Dictionary<string, ChatRoom> chatRooms)
        //{
        //    //overload for JSON initializations
        //}

        //public ChatRoom CreateRoom()
        //{

        //    _chatRooms.Add(_roomToMake, new ChatRoom(_roomToMake));
        //    int x = Convert.ToInt32(_roomToMake);
        //    x++;
        //    _roomToMake = x.ToString();
        //    return _chatRooms[(x - 1).ToString()];

        //}
        //public ChatRoom LookupRoom(string id)
        //{
        //    return _chatRooms.ContainsKey(id) ? _chatRooms[id] : null;
        //}

        //public User LookupUser(string username)
        //{
        //    return _users.ContainsKey(username) ? _users[username] : null;
        //}



        //public void AddUser(string username, string password, string sessionId)
        //{
        //    var u = new User(username, sessionId);
        //    _users.Add(username, u);
        //}

    }
}
