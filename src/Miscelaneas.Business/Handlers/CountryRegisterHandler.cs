using AutoMapper;
using MediatR;
using UpDEV.Marketplace.BusinessRules.Miscelaneas.Business.Commands;
using UpDEV.Marketplace.BusinessRules.Miscelaneas.Business.Models;
using UpDEV.Marketplace.Infrastructures.DatabaseRepository.UnitOfWork.Contracts;

namespace UpDEV.Marketplace.BusinessRules.Miscelaneas.Business.Handlers
{
    public class CountryRegisterHandler : IRequestHandler<CountryRegisterCommand, CountryDto>
    {
        private readonly IMediator mediator;
        private readonly IMiscelaneasUOW? schema;
        private readonly IMapper mapper;

        public CountryRegisterHandler(IMediator mediator, IMiscelaneasUOW miscelaneas, IMapper mapper)
        {
            this.mediator = mediator;
            this.schema = miscelaneas;
            this.mapper = mapper;
        }

        public async Task<CountryDto> Handle(CountryRegisterCommand request, CancellationToken cancellationToken)
        {
            var countryInDb = await this.schema!.Country!.FindSingleAsync(c => c!.Name! == request.Country!.Name!, cancellationToken).ConfigureAwait(false);
                    
            countryInDb ??= new Domains.Miscelaneas.Entities.CountryEntity()
            {
                CreatedAt = DateTime.UtcNow,
            };

            countryInDb.Name = request.Country!.Name;

            await this.schema!.Country!.SaveOrUpdateAsync(countryInDb, cancellationToken).ConfigureAwait(false);

            var model = mapper.Map<CountryDto>(countryInDb!);

            return await Task.FromResult(model!).ConfigureAwait(false);
        }
    }
}
