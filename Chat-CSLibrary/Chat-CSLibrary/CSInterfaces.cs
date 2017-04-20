using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Chat_CSLibrary
{
    /// <summary>
    /// Sends across the server and the chat
    /// </summary>
    [JsonObject]
    public interface IMensaje
    {
        Status MyStatus { get; }
        IUser User { get; }
        IContact Contact { get; }
        ITextMessage Message { get; }
        IChatRoom ChatRoom { get; }
        bool IsError { get; }
        string ErrorMessage { get; }
    }
    /// <summary>
    /// Used for login/logout.
    /// </summary>
    public interface IUser
    {
        string Username { get; }
        bool IsValidPassword(string password);
        void SetPassword(string currentPassword, string newPassword);
        IContactList ContactList { get; }
    }
    /// <summary>
    /// Contains all information related to a particular chat room.
    /// </summary>
    public interface IChatRoom
    {
        IContactList Contacts { get; }
        List<string> MessageHistory { get; }
        string Id { get; }
    }
    /// <summary>
    /// Contacts a list of contacts for a given user
    /// </summary>
    public interface IContactList
    {
        void AddContact(string name);
        IContact GetContact(string username);
        void RemoveContact(string name);
        List<IContact> GetAllContacts();

    }
    public interface ITextMessage
    {
        string Body { get; }
        IContact Sender { get; }
        DateTime Time { get; }
    }
    public interface IContact
    {
        string Username { get; }
        bool Status { get; }
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
