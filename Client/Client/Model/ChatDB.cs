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

    }
}
