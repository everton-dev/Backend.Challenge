using System.Collections.Generic;

namespace Backend.Challenge.Domain.Dtos
{
    /// <summary>
    /// The user dto.
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Gets or Sets the id.
        /// </summary>
        /// <value>An int.</value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or Sets the username.
        /// </summary>
        /// <value>A string.</value>
        public string Username { get; set; }
        /// <summary>
        /// Gets or Sets the email.
        /// </summary>
        /// <value>A string.</value>
        public string Email { get; set; }
    }
}