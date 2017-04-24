using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Chat_CSLibrary;

namespace Client.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Contact : IContact
    {
        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        public Status OnlineStatus { get; private set; }

        [JsonProperty]
        public string Username { get; private set; }

        [JsonConstructor]
       private Contact(string username, Status s)
        {
            OnlineStatus = s;
            Username = username;
        }

        public Contact(string username)
        {
            Username = username;
        }

        public void ChangeOnlineStatus(Status newStatus)
        {
            OnlineStatus = newStatus;
        }

    }
}
