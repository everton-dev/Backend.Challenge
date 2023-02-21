using Backend.Challenge.Domain.Dtos;
using Backend.Challenge.Domain.Interfaces;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Session;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Challenge.Infrastructure.Repositories
{
    /// <summary>
    /// The message repository.
    /// </summary>
    public class MessageRepository : RavenRepositoryBase, IMessageRepository
    {
        /// <summary>
        /// TODO: Add Summary
        /// </summary>
        /// <param name="message">The message.</param>
        public void Add(MessageDto message)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                session.Store(message);
                session.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns><![CDATA[ICollection<MessageDto>]]></returns>
        public ICollection<MessageDto> GetAll(string id, int page, int pageSize)
        {
            var messages = default(ICollection<MessageDto>);
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                messages = session.Query<MessageDto>()
                    .Where(x => x.UserId.Equals($"UserDtos/{id}"))
                    .OrderByDescending(x => x.PublicationDate)
                    .Skip(pageSize * page)
                    .Take(pageSize)
                    .ToList();
            }
            return messages;
        }

        /// <summary>
        /// Get the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A MessageDto.</returns>
        public MessageDto GetById(string id)
        {
            var message = default(MessageDto);
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                message = session.Load<MessageDto>($"MessageDtos/{id}");
            }
            return message;
        }

        /// <summary>
        /// Get the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[ICollection<MessageDto>]]></returns>
        public ICollection<MessageDto> GetById(string[] id)
        {
            var messages = default(ICollection<MessageDto>);
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                messages = session.Query<MessageDto>()
                    .Where(x => x.Id.In(id)).ToList();
            }
            return messages;
        }

        /// <summary>
        /// TODO: Add Summary
        /// </summary>
        /// <param name="message">The message.</param>
        public void Update(MessageDto message)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                session.Store(message);
                session.SaveChanges();
            }
        }

        /// <summary>
        /// TODO: Add Summary
        /// </summary>
        /// <param name="messages">The messages.</param>
        public void Update(ICollection<MessageDto> messages)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                foreach (var message in messages)
                    session.Store(message);

                session.SaveChanges();
            }
        }
    }
}