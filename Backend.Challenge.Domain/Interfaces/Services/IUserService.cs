using Backend.Challenge.Domain.Models;
using Backend.Challenge.Domain.Models.Requests;

namespace Backend.Challenge.Domain.Interfaces.Services
{
    /// <summary>
    /// The user service interface.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Retrieves the users.
        /// </summary>
        /// <returns>A GetUserResponse.</returns>
        public GetUserResponse RetrieveUsers();
        /// <summary>
        /// Retrieves the users.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A GetUserResponse.</returns>
        public GetUserResponse RetrieveUsers(string[] id);
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="request">The request.</param>
        public void SendMessage(SendMessageRequest request);
        /// <summary>
        /// Retrieves the messages.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A RetrieveMessageResponse.</returns>
        public RetrieveMessageResponse RetrieveMessages(string userId, int page, int pageSize);
        /// <summary>
        /// Retrieves the new messages.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A RetrieveMessageResponse.</returns>
        public RetrieveMessageResponse RetrieveNewMessages(string userId, int page, int pageSize);
        /// <summary>
        /// Add user.
        /// </summary>
        /// <param name="request">The request.</param>
        public void AddUser(AddUserRequest request);
        /// <summary>
        /// Reads the messages.
        /// </summary>
        /// <param name="idMessages">The id messages.</param>
        public void ReadMessages(string[] idMessages);
    }
}