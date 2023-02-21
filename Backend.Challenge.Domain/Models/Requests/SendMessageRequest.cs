namespace Backend.Challenge.Domain.Models
{
    /// <summary>
    /// The send message request.
    /// </summary>
    public class SendMessageRequest
    {
        /// <summary>
        /// Gets or Sets the user id.
        /// </summary>
        /// <value>An int.</value>
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
    }
}