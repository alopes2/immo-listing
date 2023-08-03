using ImmoListing.Business.Services;
using ImmoListing.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ImmoListing.Business.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IListingsService, ListingService>();
        
        return services;
    }
}
