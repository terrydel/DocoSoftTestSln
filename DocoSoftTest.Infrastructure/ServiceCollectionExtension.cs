using DocoSoftTest.Application.Interfaces;
using DocoSoftTest.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DocoSoftTest.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
