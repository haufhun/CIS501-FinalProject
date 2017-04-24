using Newtonsoft.Json;

namespace Server.Model
{
    public interface IMensaje
    {
        IUser User { get; }
        IContact Contact { get; }
        IContactList ContactList { get; }
        IChatRoom ChatRoom { get; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Mensaje : IMensaje
    {
        public Mensaje(Contact contact)
        {
            Contact = contact;
        }

        public Mensaje(User user)
        {
            User = user;
        }

        public Mensaje(ContactList contactList)
        {
            ContactList = contactList;
        }

        /// <summary>
        /// This constructor is ONLY to be used by Json in order to deserialize.
        /// </summary>
        /// <param name="user">The user to be passed. Can be null.</param>
        /// <param name="c">The contact to be passed. Can be null.</param>
        /// <param name="chatRoom">The chat room to be passed. Can be null.</param>
        /// <param name="contact"></param>
        [JsonConstructor]
        private Mensaje(User user, ChatRoom chatRoom, Contact contact, ContactList contactList)
        {
            User = user;
            ChatRoom = chatRoom;
            Contact = contact;
            ContactList = contactList;
        }

        public IUser User { get; }
        public IChatRoom ChatRoom { get; }
        public IContact Contact { get; }
        public IContactList ContactList { get; }
    }
}
