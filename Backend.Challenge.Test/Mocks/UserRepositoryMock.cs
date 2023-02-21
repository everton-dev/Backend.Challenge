using Backend.Challenge.Domain.Dtos;
using Backend.Challenge.Domain.Interfaces;
using Moq;
using System.Collections.Generic;

namespace Backend.Challenge.Test
{
    public static class UserRepositoryMock
    {
        public static IUserRepository UserRepository_Default() =>
            new Mock<IUserRepository>().Object;

        public static IUserRepository UserRepository_OneRegister(string[] ids)
        {
            var mock = new Mock<IUserRepository>();
            var result = default(List<UserDto>);

            if (ids?.Length > 0)
            {
                result = new List<UserDto>();
                foreach (var id in ids)
                {
                    result.Add(new UserDto()
                    {
                        Id = id,
                        Email = "email@teste.com",
                        Username = "user-test"
                    });
                }
            }

            mock.Setup(c => c.GetById(It.IsAny<string[]>())).Returns(result);

            return mock.Object;
        }

        public static IUserRepository UserRepository_UniqueRegister(string id, string email, string username)
        {
            var mock = new Mock<IUserRepository>();
            var result = default(UserDto);

            if (!string.IsNullOrWhiteSpace(id))
            {
                result = new UserDto()
                {
                    Id = id,
                    Email = email,
                    Username = username
                };
            }

            mock.Setup(c => c.GetById(It.IsAny<string>())).Returns(result);

            return mock.Object;
        }

        public static IUserRepository UserRepository_UserNotFound(string id)
        {
            var mock = new Mock<IUserRepository>();
            var result = default(UserDto);

            mock.Setup(c => c.GetById(It.IsAny<string>())).Returns(result);

            return mock.Object;
        }
    }
}