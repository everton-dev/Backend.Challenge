using Backend.Challenge.Domain.Interfaces;
using Backend.Challenge.Domain.Interfaces.Services;
using Backend.Challenge.Infrastructure.Repositories;
using Backend.Challenge.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Challenge
{
    /// <summary>
    /// The inject.
    /// </summary>
    public static class Inject
    {
        /// <summary>
        /// Add challenge IoC.
        /// </summary>
        /// <param name="service">The service.</param>
        public static void AddChallengeIoC(this IServiceCollection service)
        {
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IMessageRepository, MessageRepository>();
        }
    }
}