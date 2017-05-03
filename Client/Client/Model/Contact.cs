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
        
        //Getter and setter for online status of contact
        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        public Status OnlineStatus { get; private set; }

        //Getter and setter for username of Contact
        [JsonProperty]
        public string Username { get; private set; }

        /// <summary>
        /// This method initializes Contact with username and status
        /// </summary>
        /// <param name="username">Username passed in</param>
        /// <param name="s">Status of contact passed in</param>
        [JsonConstructor]
       private Contact(string username, Status s)
        {
            OnlineStatus = s;
            Username = username;
        }

        /// <summary>
        /// This method initializes Contact with username
        /// </summary>
        /// <param name="username">Username passed in</param>
        public Contact(string username)
        {
            Username = username;
        }

        /// <summary>
        /// This method updates the online status of a Contact
        /// </summary>
        /// <param name="newStatus">New status passed in</param>
        public void ChangeOnlineStatus(Status newStatus)
        {
            OnlineStatus = newStatus;
        }

    }
}
