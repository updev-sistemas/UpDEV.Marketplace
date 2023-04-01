using Microsoft.Extensions.DependencyInjection;
using UpDEV.Marketplace.Infrastructures.DatabaseRepository.UnitOfWork;
using UpDEV.Marketplace.Infrastructures.DatabaseRepository.UnitOfWork.Contracts;

namespace UpDEV.Marketplace.Infrastructures.DatabaseRepository.Extensions
{
    public static class RepositoryExtension
    {
        public static void RegisterRepository(this IServiceCollection service)
        {
            _ = service.AddSingleton<IMiscelaneasUOW, MiscelaneasUOW>();
        }
    }
}
