using Backend.Challenge.Domain.Models;
using Backend.Challenge.Service;
using Backend.Challenge.Test.Mocks;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Backend.Challenge.Test.Services
{
    public class UserServiceTest
    {
        public enum RetrieveMessagesType
        {
            Full,
            Half,
            Nothing
        }

        [Fact]
        public void UserService_RetrieveUsers_OneId_ReturnsTrue()
        {
            //Arrange
            var expectedId = "xyz";
            var ids = new string[] { expectedId };

            var service = new UserService(
                UserRepositoryMock.UserRepository_OneRegister(ids),
                MessageRepositoryMock.MessageRepository_Default());

            //Act
            var result = service.RetrieveUsers(ids);

            //Assert
            result.Should().NotBeNull();
            result.Users.Should().ContainSingle();
            result.Users.Single().Key.Should().BeEquivalentTo(expectedId);
            result.Users.Single().Value.Should().NotBeNull();
            result.Users.Single().Value.Id.Should().BeEquivalentTo(expectedId);
        }

        [Fact]
        public void UserService_SendMessage_ReturnsTrue()
        {
            //Arrange
            var request = new SendMessageRequest() { UserId = "xyz" };
            var service = new UserService(
                UserRepositoryMock.UserRepository_UniqueRegister("xyz", "email@test.com", "tester"),
                MessageRepositoryMock.MessageRepository_SendMessage_Success());

            //Act
            service.SendMessage(request);

            //Assert
        }

        [Fact]
        public void UserService_SendMessage_UserNotFound_ReturnsFalse()
        {
            //Arrange
            var request = new SendMessageRequest() { UserId = "xyz" };
            var service = new UserService(
                UserRepositoryMock.UserRepository_UserNotFound("xyz"),
                MessageRepositoryMock.MessageRepository_SendMessage_Success());

            //Act
            service.Invoking(y => y.SendMessage(request))
                   .Should().Throw<KeyNotFoundException>();

            //Assert
        }

        [Theory]
        [InlineData("xyz", 0, 10, RetrieveMessagesType.Full)]
        [InlineData("xyz", 1, 10, RetrieveMessagesType.Half)]
        [InlineData("xyz", 2, 10, RetrieveMessagesType.Nothing)]
        public void UserService_RetrieveMessages_ReturnsTrue(string userId, int page, int pageSize, RetrieveMessagesType type)
        {
            //Arrange
            var service = new UserService(
                UserRepositoryMock.UserRepository_Default(),
                type switch
                {
                    RetrieveMessagesType.Full => MessageRepositoryMock.MessageRepository_GetAll_PageSize_Success(userId, page, pageSize),
                    RetrieveMessagesType.Half => MessageRepositoryMock.MessageRepository_GetAll_PageSize_Half_Success(userId, page, pageSize),
                    RetrieveMessagesType.Nothing => MessageRepositoryMock.MessageRepository_GetAll_PageSize_WithoutUsers_Success(userId, page, pageSize),
                    _ => throw new ArgumentException(nameof(type))
                });

            //Act
            var result = service.RetrieveMessages(userId, page, pageSize);

            //Assert
            result.Should().NotBeNull();
            result.Messages.Should().NotBeNull();
            if (type != RetrieveMessagesType.Nothing)
            {
                pageSize = type == RetrieveMessagesType.Half ? (int)Math.Round(Convert.ToDecimal(pageSize / 2)) : pageSize;
                result.Messages.Count.Should().BeGreaterThan(0);
                result.Messages.Count.Should().Be(pageSize);
            }
        }
    }
}