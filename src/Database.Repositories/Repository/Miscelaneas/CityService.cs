using NHibernate;
using UpDEV.Marketplace.Domains.Miscelaneas.Entities;
using UpDEV.Marketplace.Infrastructures.DatabaseRepository.Common;
using UpDEV.Marketplace.Infrastructures.DatabaseRepository.Contracts;

namespace UpDEV.Marketplace.Infrastructures.DatabaseRepository.Repository.Miscelaneas
{
    public class CityService : DefaultRepository<CityEntity>, ICityService
    {
        public CityService(ISession session)
            : base(session)
        {
        }

        public async Task<IEnumerable<CityEntity>> NearbyCitiesByLocation(float latitude, float longitude, float perimeter)
        {
            var result = Array.Empty<CityEntity>();

            return await Task.FromResult(result).ConfigureAwait(false);
        }

        public async Task<IEnumerable<CityEntity>> NearbyCitiesByLocation(CityEntity target, float perimeter)
        {
            var result = Array.Empty<CityEntity>();

            return await Task.FromResult(result).ConfigureAwait(false);
        }
    }
}
