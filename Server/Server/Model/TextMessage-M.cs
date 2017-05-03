using System;
using Newtonsoft.Json;
using Chat_CSLibrary;

namespace Server.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class TextMessage : ITextMessage
    {
        /// <summary>
        /// Getter for the Body of the message
        /// </summary>
        [JsonProperty]
        public string Body { get; }

        /// <summary>
        /// Getter for the Sender of the message
        /// </summary>
        [JsonProperty]
        public IContact Sender { get; }

        /// <summary>
        /// Gets the time of the message
        /// </summary>
        [JsonProperty]
        public DateTime Time { get; } 

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
        /// Used for Json.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="sender"></param>
        /// <param name="time"></param>
        [JsonConstructor]
        private TextMessage(string body, Contact sender, DateTime time)
        {
            Body = body;
            Sender = sender;
            Time = time;
        }

        /// <summary>
        /// The time of the message being sent
        /// </summary>
        /// <returns>Format changing of the time</returns>
        public override string ToString()
        {
            return Time.ToLocalTime().ToString() + " " + Sender.Username + ":" + "\n" + Body;
        }
    }
}
