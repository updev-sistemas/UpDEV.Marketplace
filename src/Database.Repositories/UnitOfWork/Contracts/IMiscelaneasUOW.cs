using NHibernate;
using UpDEV.Marketplace.Infrastructures.DatabaseRepository.Contracts;

namespace UpDEV.Marketplace.Infrastructures.DatabaseRepository.UnitOfWork.Contracts
{
    public interface IMiscelaneasUOW
    {
        ITransaction BeginTransaction();
        Task FlushAsync(CancellationToken cancellationToken);
        ICountryService Country { get; }
        ICityService City { get; }
        IEnterpriseService Enterprise { get; }
        IMacroRegionService MacroRegion { get; }
        IStateService State { get; }
        IRegionService Region { get; }
    }
}
