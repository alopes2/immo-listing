using FluentValidation.Results;
using ImmoListing.Api.Models;

namespace ImmoListing.Api.Extensions;

public static class ValidatorExtensions
{
    public static IEnumerable<ValidationError> GetValidationErrors(this ValidationResult validationResult)
    {   
        return validationResult
            .Errors
            .GroupBy(x => x.PropertyName)
            .Select(g =>
            {
                return new ValidationError(
                    g.Key,
                    g.Select(x => x.ErrorMessage).ToArray()
                );
            });
    }
}
