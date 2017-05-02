using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Chat_CSLibrary;

namespace Server.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Contact : IContact
    {
        /// <summary>
        /// The field to keep track of the Contact's Online Status
        /// </summary>
        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        public Status OnlineStatus { get; private set; }

        /// <summary>
        /// The Contact's Username
        /// </summary>
        [JsonProperty]
        public string Username { get; private set; }

        /// <summary>
        /// The Constructore that sets the online status and the username
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="s">The Online Status</param>
        [JsonConstructor]
        public Contact(string username, Status s)
        {
            OnlineStatus = s;
            Username = username;
        }

        /// <summary>
        /// Changes the Contact's Online Status to the value of the paraemter
        /// </summary>
        /// <param name="newStatus">The new Online Status</param>
        public void ChangeOnlineStatus(Status newStatus)
        {
            OnlineStatus = newStatus;
        }

    }
}
