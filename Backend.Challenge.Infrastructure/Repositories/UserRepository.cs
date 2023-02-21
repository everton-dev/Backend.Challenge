using Backend.Challenge.Domain.Dtos;
using Backend.Challenge.Domain.Interfaces;
using Raven.Client.Documents;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Session;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Challenge.Infrastructure.Repositories
{
    /// <summary>
    /// The user repository.
    /// </summary>
    public class UserRepository : RavenRepositoryBase, IUserRepository
    {
        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <returns><![CDATA[ICollection<UserDto>]]></returns>
        public ICollection<UserDto> GetAll()
        {
            var users = default(ICollection<UserDto>);
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                users = session.Query<UserDto>().ToList();
            }
            return users;
        }

        /// <summary>
        /// Get the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>An UserDto.</returns>
        public UserDto GetById(string id)
        {
            var user = default(UserDto);
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                user = session.Load<UserDto>($"UserDtos/{id}");
            }
            return user;
        }

        /// <summary>
        /// Get the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[ICollection<UserDto>]]></returns>
        public ICollection<UserDto> GetById(string[] id)
        {
            var users = default(ICollection<UserDto>);
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                users = session.Query<UserDto>()
                    .Where(x => x.Id.In(id)).ToList();
            }
            return users;
        }

        /// <summary>
        /// TODO: Add Summary
        /// </summary>
        /// <param name="user">The user.</param>
        public void Insert(UserDto user)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                session.Store(user);
                session.SaveChanges();
            }
        }

        /// <summary>
        /// TODO: Add Summary
        /// </summary>
        /// <param name="user">The user.</param>
        public void Update(UserDto user)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                session.Store(user);
                session.SaveChanges();
            }
        }
    }
}