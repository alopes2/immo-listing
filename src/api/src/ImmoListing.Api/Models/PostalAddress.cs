namespace ImmoListing.Api.Models;

public record PostalAddress(
        string StreetAddress,
        string PostalCode,
        string City,
        string Country
);
