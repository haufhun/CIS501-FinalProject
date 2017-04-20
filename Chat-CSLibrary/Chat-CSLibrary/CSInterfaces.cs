using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * Questions for you guys:
 * 
 * Does a chat room have two users inside of it, or does a user have a chat room? Different implementations for each
 * 
 * Do we just have these interfaces, and then have both server and client implement these? This may be easier to distinguish between what each should know... or how each should access the data
 *      For example, we don't want the client to have access to the password, but the server does need it.
 * 
 * What is the difference between a contact and a user? 
 * When is it appropriate to use one or the other? 
 * Does a contact have the same info as a user, but just the username?
 */

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
        /// <summary>
        /// The username fo the particular user.
        /// </summary>
        string Username { get; }

        /// <summary>
        /// The password for this user.
        /// </summary>
        string Password { get; }
        
        IContactList ContactList { get; }
    }
    /// <summary>
    /// Contains all information related to a particular chat room.
    /// </summary>
    public interface IChatRoom
    {
        /// <summary>
        /// A list of all the messages in a chat room for a new user in a chat room.
        /// </summary>
        List<string> MessageHistory { get; }
        /// <summary>
        /// The unique id describing this particular chat room.
        /// </summary>
        string Id { get; }
        /// <summary>
        /// Used to find how many people are in this particular chat room.
        /// </summary>
        /// <returns>The number of people in the chat room.</returns>
        int NumberOfPartcipants();
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
