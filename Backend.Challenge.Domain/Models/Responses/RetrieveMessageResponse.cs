using Backend.Challenge.Domain.Dtos;
using System.Collections.Generic;

namespace Backend.Challenge.Domain.Models
{
    /// <summary>
    /// The retrieve message response.
    /// </summary>
    public class RetrieveMessageResponse
    {
        /// <summary>
        /// Gets or Sets the messages.
        /// </summary>
        /// <value>A list of messagedtos.</value>
        public ICollection<MessageDto> Messages { get; set; }
    }
}