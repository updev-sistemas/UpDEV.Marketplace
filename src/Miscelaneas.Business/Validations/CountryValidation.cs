using FluentValidation;
using UpDEV.Marketplace.BusinessRules.Miscelaneas.Business.Models;

namespace UpDEV.Marketplace.BusinessRules.Miscelaneas.Business.Validations
{
    public class CountryValidation : AbstractValidator<CountryDto>
    {
        public CountryValidation()
        {
            RuleSet("CountryCreate", () =>
            {
                RuleFor(p => p.Name).NotEmpty().MinimumLength(2).MaximumLength(100);
            });

            RuleSet("CountryUpdate", () =>
            {
                RuleFor(p => p.Name).NotEmpty().MinimumLength(2).MaximumLength(100);
            });
        }
    }
}
