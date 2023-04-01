using MediatR;
using UpDEV.Marketplace.BusinessRules.Miscelaneas.Business.Models;

namespace UpDEV.Marketplace.BusinessRules.Miscelaneas.Business.Commands
{
    public class CountryRegisterCommand : IRequest<CountryDto>
    {
        public CountryRegisterCommand(CountryDto? country)
        {
            this.Country = country;
        }

        public virtual CountryDto? Country { get; set; }
    }
}
