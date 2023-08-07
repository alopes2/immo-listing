using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ImmoListing.Data.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddDatabase(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ImmoListingDbContext>(options => {
            options.UseSqlServer(
                builder.Configuration.GetConnectionString(ImmoListingDbContext.ConnectionString),
                config => config.MigrationsAssembly(typeof(ImmoListingDbContext).Assembly.FullName));
        });

        return builder;
    }
    public static WebApplication MigrateDatabaseIfContainer(this WebApplication app)
    {
        if (app.Environment.IsEnvironment("Container"))
        {
            var dbContext = app.Services.GetRequiredService<ImmoListingDbContext>();

            dbContext.Database.Migrate();
        }

        return app;
    }
}
