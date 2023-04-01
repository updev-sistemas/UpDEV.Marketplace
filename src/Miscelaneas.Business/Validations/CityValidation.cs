using FluentValidation;
using UpDEV.Marketplace.BusinessRules.Miscelaneas.Business.Models;
using UpDEV.Marketplace.Domains.Common.Enumerables;

namespace UpDEV.Marketplace.BusinessRules.Miscelaneas.Business.Validations
{
    public class CityValidation : AbstractValidator<CityDto>
    {
        public CityValidation()
        {
            RuleSet("CityCreate", () =>
            {
                RuleFor(p => p.Id).Null().Empty();
                RuleFor(p => p.Name).NotEmpty().Length(100);
                RuleFor(p => p.IbgeCode).NotEmpty().Length(20);
                RuleFor(p => p.DDD).NotEmpty().InclusiveBetween(10,99);
                RuleFor(p => p.Latitude).NotEmpty().InclusiveBetween(-180, 180);
                RuleFor(p => p.Longitude).NotEmpty().InclusiveBetween(-180, 180);
                RuleFor(p => p.Perimeter).NotEmpty().InclusiveBetween(0, 10000);
                RuleFor(p => p.Zone).NotNull().IsInEnum<CityDto, CityZone?>().NotEmpty();
            });

            RuleSet("CityUpdate", () =>
            {
                RuleFor(p => p.Id).Null().Empty();
                RuleFor(p => p.Name).NotEmpty().Length(100);
                RuleFor(p => p.IbgeCode).NotEmpty().Length(20);
                RuleFor(p => p.DDD).NotEmpty().InclusiveBetween(10, 99);
                RuleFor(p => p.Latitude).NotEmpty().InclusiveBetween(-180, 180);
                RuleFor(p => p.Longitude).NotEmpty().InclusiveBetween(-180, 180);
                RuleFor(p => p.Perimeter).NotEmpty().InclusiveBetween(0, 10000);
                RuleFor(p => p.Zone).NotNull().IsInEnum<CityDto, CityZone?>().NotEmpty();
            });
        }
    }
}
