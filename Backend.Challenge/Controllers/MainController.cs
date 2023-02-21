using Backend.Challenge.Domain.Interfaces.Services;
using Backend.Challenge.Domain.Models;
using Backend.Challenge.Domain.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Challenge.Controllers
{
    public class MainController : Controller
    {
        private readonly IUserService _service;
        public MainController(IUserService userService) =>
            _service = userService;

        // This action responds to the url /main/users/42 and /main/users?id=4&id=10
        public GetUserResponse Users(string[] id) =>
            _service.RetrieveUsers(id);

        public GetUserResponse AllUsers() =>
            _service.RetrieveUsers();

        // TODO: An action to return a paged list of comments
        // This action responds to the url /main/RetrieveMessages?id=4&page=10&pageSize=5
        public RetrieveMessageResponse RetrieveMessages(string id, int page, int pageSize) =>
            _service.RetrieveMessages(id, page, pageSize);

        public RetrieveMessageResponse RetrieveNewMessages(string id, int page, int pageSize) =>
            _service.RetrieveNewMessages(id, page, pageSize);

        // TODO: An action to add a comment
        [HttpPost]
        public void SendMessage([FromBody] SendMessageRequest request) =>
            _service.SendMessage(request);

        [HttpPost]
        public void AddUser([FromBody] AddUserRequest request) =>
            _service.AddUser(request);

        [HttpPost]
        public void ReadMessages([FromBody] ReadMessageRequest request) =>
            _service.ReadMessages(request.MessagesId);
    }
}