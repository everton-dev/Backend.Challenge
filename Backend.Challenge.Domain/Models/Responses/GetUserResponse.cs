using Backend.Challenge.Domain.Dtos;
using System.Collections.Generic;

namespace Backend.Challenge.Domain.Models
{
    /// <summary>
    /// The get user response.
    /// </summary>
    public class GetUserResponse
    {
        /// <summary>
        /// Gets or Sets the users.
        /// </summary>
        /// <value>A dictionary with a key of type integer and a value of type userdtos.</value>
        public Dictionary<string, UserDto> Users { get; set; }
    }
}