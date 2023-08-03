namespace ImmoListing.Api.Models;

public record PostalAddressResource(
        string StreetAddress,
        string PostalCode,
        string City,
        string Country
);
