using System;

namespace Backend.Challenge.Domain.Dtos
{
    /// <summary>
    /// The message dto.
    /// </summary>
    public class MessageDto
    {
        /// <summary>
        /// Gets or Sets the id.
        /// </summary>
        /// <value>A string.</value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or Sets the user id.
        /// </summary>
        /// <value>A string.</value>
        public string UserId { get; set; }
        /// <summary>
        /// Gets or Sets the message.
        /// </summary>
        /// <value>A string.</value>
        public string Message { get; set; }
        /// <summary>
        /// Gets or Sets the author.
        /// </summary>
        /// <value>A string.</value>
        public string Author { get; set; }
        /// <summary>
        /// Gets or Sets the publication date.
        /// </summary>
        /// <value>A DateTimeOffset.</value>
        public DateTimeOffset PublicationDate { get; set; }
        /// <summary>
        /// Gets or Sets a value indicating whether new message.
        /// </summary>
        /// <value>A bool.</value>
        public bool NewMessage { get; set; }
    }
}