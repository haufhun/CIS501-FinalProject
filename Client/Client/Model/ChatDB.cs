using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat_CSLibrary;
namespace Client.Model
{
    /// <summary>
    /// This is the class in the Model for ChatDB
    /// </summary>
    public class ChatDB
    {
        /// <summary>
        /// Getter and setter for user
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets the Dictionary storing the chatrooms
        /// </summary>
        public Dictionary<string, ChatRoom> ChatRooms { get;}

        /// <summary>
        /// Gets the Dictionary storing the chatroom we are on currently
        /// </summary>
        public Dictionary<string,ChatForm> CurrentChatForm { get;}
        
        /// <summary>
        /// Initializes the Chat Database
        /// </summary>
        public ChatDB()
        {
            User = new User(null, null);
            ChatRooms = new Dictionary<string, ChatRoom>();
            CurrentChatForm = new Dictionary<string, ChatForm>();
        }



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
