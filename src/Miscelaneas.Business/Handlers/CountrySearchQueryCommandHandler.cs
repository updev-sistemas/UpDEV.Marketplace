using AutoMapper;
using MediatR;
using UpDEV.Marketplace.BusinessRules.Miscelaneas.Business.Commands;
using UpDEV.Marketplace.BusinessRules.Miscelaneas.Business.Models;
using UpDEV.Marketplace.Domains.Miscelaneas.Entities;
using UpDEV.Marketplace.Infrastructures.DatabaseRepository.UnitOfWork.Contracts;

namespace UpDEV.Marketplace.BusinessRules.Miscelaneas.Business.Handlers
{
    public class CountrySearchQueryCommandHandler : IRequestHandler<CountrySearchQueryCommand, PaginationDto<IEnumerable<CountryDto>>>
    {
        private readonly IMediator? mediator;
        private readonly IMiscelaneasUOW? schema;
        private readonly IMapper? mapper;

        public CountrySearchQueryCommandHandler(IMediator mediator, IMiscelaneasUOW miscelaneas, IMapper mapper)
        {
            this.mediator = mediator;
            this.schema = miscelaneas;
            this.mapper = mapper;
        }

        public async Task<PaginationDto<IEnumerable<CountryDto>>> Handle(CountrySearchQueryCommand request, CancellationToken cancellationToken)
        {
            int currentPage = (request.CurrentPage ?? 0) - 1;
            int perPage = request.PerPage ?? 10;

            int total = await this.schema!.Country.CountAsync(p => (string.IsNullOrEmpty(request.Name) || (!string.IsNullOrEmpty(request.Name) && request.Name == p.Name)), cancellationToken).ConfigureAwait(false);
            IEnumerable<CountryEntity>? result = await this.schema!.Country.FindWithPaginationAsync(currentPage, perPage, p => (string.IsNullOrEmpty(request.Name) || (!string.IsNullOrEmpty(request.Name) && request.Name == p.Name)), cancellationToken, o => o.OrderBy(p => p.Name)).ConfigureAwait(false);

            var resultToReturn = this.mapper!.Map<IEnumerable<CountryDto>>(result);

            var pagination = new PaginationDto<IEnumerable<CountryDto>>(total, perPage, currentPage + 1, resultToReturn);

            return await Task.FromResult(pagination).ConfigureAwait(false);
        }
    }
}
