using System;
using System.Collections.Generic;

namespace Chat_CSLibrary
{
    /// <summary>
    /// Sends across the server and the chat
    /// </summary>
    public interface IMensaje
    {
        Status MyStatus { get; set; }
        IUser User { get; set; }
        IContact Contact { get; set; }
        ITextMessage Message { get; set; }
        IChatRoom ChatRoom { get; set; }
    }
    /// <summary>
    /// Used for login/logout.
    /// </summary>
    public interface IUser
    {
        string Username { get; }
        string Password { get; }
        IContactList ContactList { get; }
    }
    /// <summary>
    /// Contains all information related to a particular chat room.
    /// </summary>
    public interface IChatRoom
    {
        IContactList Contacts { get; set; }
        List<string> MessageHistory { get; set; }
        string Id { get; }
    }
    /// <summary>
    /// Contacts a list of contacts for a given user
    /// </summary>
    public interface IContactList
    {
        List<IContact> Contacts { get; set; }
        void AddContact(string name);
        void RemoveContact(string name);
    }

    public interface ITextMessage
    {
        string Body { get; set; }
        IContact Sender { get; set; }
        DateTime Time { get; set; }
    }

    public interface IContact
    {
        string Username { get; set; }
        bool Status { get; set; }
    }

    public enum Status
    {
        AddContact,
        AddContactToChat,
        Login,
        Logout,
        OpenChat,
        RemoveContact,
        SendTextMessage
    }
}
