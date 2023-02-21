using Backend.Challenge.Domain.Dtos;
using System.Collections.Generic;

namespace Backend.Challenge.Domain.Interfaces
{
    /// <summary>
    /// The user repository interface.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// TODO: Add Summary
        /// </summary>
        /// <param name="user">The user.</param>
        public void Insert(UserDto user);
        /// <summary>
        /// TODO: Add Summary
        /// </summary>
        /// <param name="user">The user.</param>
        public void Update(UserDto user);
        /// <summary>
        /// Get the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>An UserDto.</returns>
        public UserDto GetById(string id);
        /// <summary>
        /// Get the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[ICollection<UserDto>]]></returns>
        public ICollection<UserDto> GetById(string[] id);
        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <returns><![CDATA[ICollection<UserDto>]]></returns>
        public ICollection<UserDto> GetAll();
    }
}