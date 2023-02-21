using Backend.Challenge.Domain.Dtos;
using Backend.Challenge.Domain.Interfaces;
using Backend.Challenge.Domain.Interfaces.Services;
using Backend.Challenge.Domain.Models;
using Backend.Challenge.Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Challenge.Service
{
    /// <summary>
    /// The user service.
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// The user repository.
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// The message repository.
        /// </summary>
        private readonly IMessageRepository _messageRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public UserService(IUserRepository repository, IMessageRepository messageRepository)
        {
            _userRepository = repository;
            _messageRepository = messageRepository;
        }

        /// <summary>
        /// Retrieves the users.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <returns>A GetUserResponse.</returns>
        public GetUserResponse RetrieveUsers(string[] id)
        {
            for (var i = 0; i < id.Length; i++)
                id[i] = $"UserDtos/{id[i]}";

            var users = _userRepository.GetById(id);
            if (users == null)
                throw new InvalidOperationException(nameof(users));

            return new GetUserResponse
            {
                Users = users.ToDictionary(_ => _.Id, _ => _)
            };
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <exception cref="KeyNotFoundException"></exception>
        public void SendMessage(SendMessageRequest request)
        {
            var user = _userRepository.GetById(request.UserId);
            if (user == null)
                throw new KeyNotFoundException();

            _messageRepository.Add(new MessageDto()
            {
                UserId = user.Id,
                Message = request.Message,
                Author = request.Author,
                PublicationDate = DateTimeOffset.UtcNow,
                NewMessage = true
            });
        }

        /// <summary>
        /// Retrieves the messages.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A RetrieveMessageResponse.</returns>
        public RetrieveMessageResponse RetrieveMessages(string userId, int page, int pageSize)
        {
            return new RetrieveMessageResponse()
            {
                Messages = _messageRepository.GetAll(userId, page, pageSize)
            };
        }

        /// <summary>
        /// Add user.
        /// </summary>
        /// <param name="request">The request.</param>
        public void AddUser(AddUserRequest request)
        {
            var user = new UserDto()
            {
                Username = request.Username,
                Email = request.Email
            };

            _userRepository.Insert(user);
        }

        /// <summary>
        /// Retrieves the users.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        /// <returns>A GetUserResponse.</returns>
        public GetUserResponse RetrieveUsers()
        {
            var users = _userRepository.GetAll();
            if (users == null)
                throw new InvalidOperationException(nameof(users));

            return new GetUserResponse
            {
                Users = users.ToDictionary(_ => _.Id, _ => _)
            };
        }

        /// <summary>
        /// Reads the messages.
        /// </summary>
        /// <param name="idMessages">The id messages.</param>
        /// <exception cref="InvalidOperationException"></exception>
        public void ReadMessages(string[] idMessages)
        {
            for (var i = 0; i < idMessages.Length; i++)
                idMessages[i] = $"MessageDtos/{idMessages[i]}";

            var messages = _messageRepository.GetById(idMessages);
            if (messages == null)
                throw new InvalidOperationException(nameof(messages));

            foreach (var message in messages)
                message.NewMessage = false;

            _messageRepository.Update(messages);
        }
    }
}