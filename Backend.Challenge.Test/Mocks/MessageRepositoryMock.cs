using Backend.Challenge.Domain.Dtos;
using Backend.Challenge.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;

namespace Backend.Challenge.Test.Mocks
{
    public class MessageRepositoryMock
    {
        public static IMessageRepository MessageRepository_Default() =>
            new Mock<IMessageRepository>().Object;

        public static IMessageRepository MessageRepository_SendMessage_Success()
        {
            var mock = new Mock<IMessageRepository>(MockBehavior.Strict);

            mock.Setup(c => c.Add(It.IsAny<MessageDto>()));

            return mock.Object;
        }

        public static IMessageRepository MessageRepository_GetAll_PageSize_Success(string userId, int page, int pageSize)
        {
            var mock = new Mock<IMessageRepository>(MockBehavior.Strict);
            var messages = default(List<MessageDto>);

            if (pageSize > 0)
            {
                messages = new List<MessageDto>();
                for (int i = 1; i <= pageSize; i++)
                {
                    messages.Add(new MessageDto()
                    {
                        Id = $"MessageDtos/{i}-A",
                        UserId = userId,
                        Author = $"Author_{i}",
                        Message = $"Message XYZ {i}",
                        PublicationDate = System.DateTimeOffset.UtcNow,
                        NewMessage = i % 2 == 0,
                    });
                }
            }

            mock.Setup(c => c.GetAll(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(messages);

            return mock.Object;
        }

        public static IMessageRepository MessageRepository_GetAll_PageSize_Half_Success(string userId, int page, int pageSize)
        {
            var mock = new Mock<IMessageRepository>(MockBehavior.Strict);
            var messages = default(List<MessageDto>);

            if (pageSize > 0)
            {
                pageSize = (int)Math.Round(Convert.ToDecimal(pageSize / 2));
                messages = new List<MessageDto>();
                for (int i = 1; i <= pageSize; i++)
                {
                    messages.Add(new MessageDto()
                    {
                        Id = $"MessageDtos/{i}-A",
                        UserId = userId,
                        Author = $"Author_{i}",
                        Message = $"Message XYZ {i}",
                        PublicationDate = System.DateTimeOffset.UtcNow,
                        NewMessage = i % 2 == 0,
                    });
                }
            }

            mock.Setup(c => c.GetAll(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(messages);

            return mock.Object;
        }

        public static IMessageRepository MessageRepository_GetAll_PageSize_WithoutUsers_Success(string userId, int page, int pageSize)
        {
            var mock = new Mock<IMessageRepository>(MockBehavior.Strict);
            var messages = default(List<MessageDto>);

            if (pageSize > 0)
            {
                messages = new List<MessageDto>();
            }

            mock.Setup(c => c.GetAll(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(messages);

            return mock.Object;
        }
    }
}