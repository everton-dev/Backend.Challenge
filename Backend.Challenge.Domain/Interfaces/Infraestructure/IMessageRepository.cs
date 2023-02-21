using Backend.Challenge.Domain.Dtos;
using System.Collections.Generic;

namespace Backend.Challenge.Domain.Interfaces
{
    /// <summary>
    /// The message repository interface.
    /// </summary>
    public interface IMessageRepository
    {
        /// <summary>
        /// TODO: Add Summary
        /// </summary>
        /// <param name="message">The message.</param>
        public void Add(MessageDto message);
        /// <summary>
        /// TODO: Add Summary
        /// </summary>
        /// <param name="message">The message.</param>
        public void Update(MessageDto message);
        /// <summary>
        /// TODO: Add Summary
        /// </summary>
        /// <param name="messages">The messages.</param>
        public void Update(ICollection<MessageDto> messages);
        /// <summary>
        /// Get the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A MessageDto.</returns>
        public MessageDto GetById(string id);
        /// <summary>
        /// Get the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[ICollection<MessageDto>]]></returns>
        public ICollection<MessageDto> GetById(string[] id);
        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns><![CDATA[ICollection<MessageDto>]]></returns>
        public ICollection<MessageDto> GetAll(string id, int page, int pageSize);
        /// <summary>
        /// Gets the all new messages.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns><![CDATA[ICollection<MessageDto>]]></returns>
        public ICollection<MessageDto> GetAllNewMessages(string id, int page, int pageSize);
    }
}