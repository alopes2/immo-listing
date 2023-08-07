using FluentValidation;
using ImmoListing.Api.Models;

namespace ImmoListing.Api.Validators;

public class PostalAddressValidator : AbstractValidator<PostalAddressResource>
{
    public PostalAddressValidator()
    {
        RuleFor(l => l.City)
            .NotEmpty();

        RuleFor(l => l.Country)
            .NotEmpty();

        RuleFor(l => l.PostalCode)
            .NotEmpty()
            .MinimumLength(4);

        RuleFor(l => l.StreetAddress)
            .NotEmpty();
    }
}
