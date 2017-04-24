using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Server.Model
{
    public interface IContact
    {
        bool IsOnline { get; }
        string Username { get; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Contact : IContact
    {
        [JsonProperty]
        public bool IsOnline { get; private set; }
        [JsonProperty]
        public string Username { get; private set; }

        [JsonConstructor]
        public Contact(string username)
        {
            IsOnline = true;
            Username = username;
        }

        public void ChangeOnlineStatus(bool newStatus)
        {
            IsOnline = newStatus;
        }

    }
}
