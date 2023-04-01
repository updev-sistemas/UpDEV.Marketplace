using NHibernate;
using UpDEV.Marketplace.Domains.Miscelaneas.Entities;
using UpDEV.Marketplace.Infrastructures.DatabaseRepository.Common;
using UpDEV.Marketplace.Infrastructures.DatabaseRepository.Contracts;

namespace UpDEV.Marketplace.Infrastructures.DatabaseRepository.Repository.Miscelaneas
{
    public class EnterpriseService : DefaultRepository<EnterpriseEntity>, IEnterpriseService
    {
        public EnterpriseService(ISession session) : base(session)
        {
        }
    }
}
