using MediatR;
using UpDEV.Marketplace.BusinessRules.Miscelaneas.Business.Models;

namespace UpDEV.Marketplace.BusinessRules.Miscelaneas.Business.Commands
{
    public class CountrySearchQueryCommand : IRequest<PaginationDto<IEnumerable<CountryDto>>>
    {
        public virtual string? Name { get; set; }
        public virtual int? PerPage { get; set; }
        public virtual int? CurrentPage { get; set; }
    }
}
