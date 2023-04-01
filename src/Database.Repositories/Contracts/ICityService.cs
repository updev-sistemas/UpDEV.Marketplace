using UpDEV.Marketplace.Domains.Common.Contracts;
using UpDEV.Marketplace.Domains.Miscelaneas.Entities;

namespace UpDEV.Marketplace.Infrastructures.DatabaseRepository.Contracts
{
    public interface ICityService : IDefaultRepository<CityEntity>
    {
        Task<IEnumerable<CityEntity>> NearbyCitiesByLocation(CityEntity target, float perimeter);
        Task<IEnumerable<CityEntity>> NearbyCitiesByLocation(float latitude, float longitude, float perimeter);
    }
}