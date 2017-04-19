using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat_CSLibrary;

namespace Server.Model
{
    public class ChatDB
    {
        private Dictionary<string, IUser> _users;
        private Dictionary<string, IChatRoom> _chatRooms;

        public ChatDB()
        {
            _users = new Dictionary<string, IUser>();
            _chatRooms = new Dictionary<string, IChatRoom>();
        }
    }
}
