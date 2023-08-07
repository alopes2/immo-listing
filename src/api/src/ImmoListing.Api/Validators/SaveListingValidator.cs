using System.Text.RegularExpressions;
using FluentValidation;
using ImmoListing.Api.Models;

namespace ImmoListing.Api.Validators;

public class SaveListingValidator : AbstractValidator<SaveListingResource>
{
        public SaveListingValidator()
        {
            RuleFor(l => l.Name)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(l => l.BedroomsCount)
                .NotEmpty();

            RuleFor(l => l.RoomsCount)
                .NotEmpty();

            RuleFor(l => l.BuildingType)
                .NotEmpty();

            RuleFor(l => l.ContactPhoneNumber)
                .NotEmpty()
                .MaximumLength(20)
                .Must(number => {
                    var regex = new Regex("^\\+|[0-9]{1}[0-9]*$");

                    return regex.IsMatch(number);
                });

            RuleFor(l => l.Description)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(l => l.LatestPriceEur)
                .NotEmpty();

            RuleFor(l => l.SurfaceAreaM2)
                .NotEmpty();

            RuleFor(l => l.PostalAddress)
                .NotEmpty()
                .SetValidator(new PostalAddressValidator());
        }
}
