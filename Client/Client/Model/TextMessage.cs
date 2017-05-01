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
        //
        [JsonProperty]
        public string Body { get; }

        //
        [JsonProperty]
        public IContact Sender { get; }

        //
        [JsonProperty]
        public DateTime Time { get; } 

        /// <summary>
        /// Use this when constructing a new TextMessage object.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="sender"></param>
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
    }
}
