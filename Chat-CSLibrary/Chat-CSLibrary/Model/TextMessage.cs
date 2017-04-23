using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat_CSLibrary;

namespace Server.Model
{
    public class TextMessage : ITextMessage
    {
        public string Body { get; }
        public IContact Sender { get; }
        public DateTime Time { get; }

        public TextMessage(string body, IContact sender, DateTime time)
        {
            Body = body;
            this.Sender = sender;
            this.Time = time;
        }
    }
}
