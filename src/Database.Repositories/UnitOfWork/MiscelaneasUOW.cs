using NHibernate;
using UpDEV.Marketplace.Infrastructures.DatabaseFactory.Factory;
using UpDEV.Marketplace.Infrastructures.DatabaseRepository.Contracts;
using UpDEV.Marketplace.Infrastructures.DatabaseRepository.Repository.Miscelaneas;
using UpDEV.Marketplace.Infrastructures.DatabaseRepository.UnitOfWork.Contracts;

namespace UpDEV.Marketplace.Infrastructures.DatabaseRepository.UnitOfWork
{
    public class MiscelaneasUOW : IMiscelaneasUOW
    {
        private readonly ISession? _session;

        private ICountryService? _country;
        private ICityService? _city;
        private IEnterpriseService? _enterprise;
        private IMacroRegionService? _macroRegion;
        private IStateService? _state;
        private IRegionService? _region;

        public MiscelaneasUOW(IDatabaseFactory factory)
        {
            ArgumentNullException.ThrowIfNull(factory, "Fabrica de conexão estava inválida.");

            _session = factory!.OpenSession();
            _session.FlushMode = FlushMode.Auto;

            _country = new CountryService(_session);
            _city = new CityService(_session);
            _enterprise = new EnterpriseService(_session);
            _macroRegion = new MacroRegionService(_session);
            _state = new StateService(_session);
            _region = new RegionService(_session);
        }

        public ICountryService Country => _country!;
        public ICityService City => _city!;
        public IEnterpriseService Enterprise => _enterprise!;
        public IMacroRegionService MacroRegion => _macroRegion!;
        public IStateService State => _state!;
        public IRegionService Region => _region!;

        public ITransaction BeginTransaction()
        {
            return _session!.BeginTransaction();
        }

        public async Task FlushAsync(CancellationToken cancellationToken)
        {
            await _session!.FlushAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
