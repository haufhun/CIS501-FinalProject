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
    }
}
