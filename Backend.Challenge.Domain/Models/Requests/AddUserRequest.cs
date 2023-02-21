namespace Backend.Challenge.Domain.Models.Requests
{
    /// <summary>
    /// The add user request.
    /// </summary>
    public class AddUserRequest
    {
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