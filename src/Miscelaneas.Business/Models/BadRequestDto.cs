using FluentValidation.Results;

namespace UpDEV.Marketplace.BusinessRules.Miscelaneas.Business.Models
{
    public record BadRequestDto<T>(T Target, IEnumerable<ValidationFailure>? Errors, IEnumerable<string>? RulesSetExecuted, bool? IsValid) where T : class;
}
