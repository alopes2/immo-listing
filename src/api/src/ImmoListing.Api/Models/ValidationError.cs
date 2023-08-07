namespace ImmoListing.Api.Models;

public record ValidationError
(
    string Property,
    string[] Errors
);
