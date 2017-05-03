using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Chat_CSLibrary;

namespace Client.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class TextMessage : ITextMessage
    {
        //Getter for the Body of the message
        [JsonProperty]
        public string Body { get; }

        //Getter for the sender of the message
        [JsonProperty]
        public IContact Sender { get; }

        //Gets the time of the message
        [JsonProperty]
        public DateTime Time { get; }
        /// <summary>
        /// Used for Json.
        /// </summary>
        /// <param name="body">The body of the message</param>
        /// <param name="sender">The contact sending the message</param>
        /// <param name="time">The time the message is sent</param>
        [JsonConstructor]
        private TextMessage(string body, Contact sender, DateTime time)
        {
            Body = body;
            Sender = sender;
            Time = time;
        }
        /// <summary>
        /// Use this when constructing a new TextMessage object.
        /// </summary>
        /// <param name="body">Body of the message</param>
        /// <param name="sender">Contact sending the message</param>
        public TextMessage(string body, IContact sender)
        {
            Body = body;
            Sender = sender;
            Time = DateTime.Now;
        }

        /// <summary>
        /// The time of the message being sent.
        /// </summary>
        /// <returns>Format changing of the time</returns>
        public override string ToString()
        {
            return Time.ToLocalTime().ToString() + " " + Sender.Username + ":" + "\n" + Body;
        }
    }
}
