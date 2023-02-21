namespace Backend.Challenge.Domain.Models.Requests
{
    /// <summary>
    /// The read message request.
    /// </summary>
    public class ReadMessageRequest
    {
        /// <summary>
        /// Gets or Sets the messages id.
        /// </summary>
        /// <value>An array of strings</value>
        public string[] MessagesId { get; set; }
    }
}