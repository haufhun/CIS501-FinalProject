using Newtonsoft.Json;

namespace Server.Model
{
    public interface IMensaje
    {
        IUser User { get; }
        IContact Contact { get; }
        IContactList ContactList { get; }
        IChatRoom ChatRoom { get; }
        ITextMessage TextMessage { get; }
        bool IsError { get; }
        string ErrorMessage { get; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Mensaje : IMensaje
    {
        [JsonProperty]
        public IUser User { get; }
        [JsonProperty]
        public IChatRoom ChatRoom { get; }
        [JsonProperty]
        public IContact Contact { get; }
        [JsonProperty]
        public IContactList ContactList { get; }
        [JsonProperty]
        public ITextMessage TextMessage { get;  }
        [JsonProperty]
        public bool IsError { get; }
        [JsonProperty]
        public string ErrorMessage { get; }
        //Use for testing
        public Mensaje(Contact contact)
        {
            Contact = contact;
        }

        //Use for testing
        public Mensaje(User user)
        {
            User = user;
        }

        //Use for testing
        public Mensaje(ContactList contactList)
        {
            ContactList = contactList;
        }

        //Use for testing
        public Mensaje(TextMessage textMessage)
        {
            TextMessage = textMessage;
        }

        /// <summary>
        /// A constructor that constructs an error Mensaje to send back to the client.
        /// </summary>
        /// <param name="errorMessage"></param>
        public Mensaje(string errorMessage)
        {
            IsError = true;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// This constructor is ONLY to be used by Json in order to deserialize.
        /// </summary>
        /// <param name="user">The user to be passed. Can be null.</param>
        /// <param name="c">The contact to be passed. Can be null.</param>
        /// <param name="chatRoom">The chat room to be passed. Can be null.</param>
        /// <param name="contact"></param>
        [JsonConstructor]
        private Mensaje(User user, ChatRoom chatRoom, Contact contact, ContactList contactList, TextMessage textMessage, bool isError, string errorMessage)
        {
            User = user;
            ChatRoom = chatRoom;
            Contact = contact;
            ContactList = contactList;
            TextMessage = textMessage;
        }
    }
}
