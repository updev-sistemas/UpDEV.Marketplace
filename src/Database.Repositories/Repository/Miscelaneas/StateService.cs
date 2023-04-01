using NHibernate;
using UpDEV.Marketplace.Domains.Miscelaneas.Entities;
using UpDEV.Marketplace.Infrastructures.DatabaseRepository.Common;
using UpDEV.Marketplace.Infrastructures.DatabaseRepository.Contracts;

namespace UpDEV.Marketplace.Infrastructures.DatabaseRepository.Repository.Miscelaneas
{
    public class StateService : DefaultRepository<StateEntity>, IStateService
    {
        public StateService(ISession session) : base(session)
        {
        }
    }
}
