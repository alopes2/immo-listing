using ImmoListing.Api.Models;
using ImmoListing.Core.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ImmoListing.Api.Swagger;

public class OperationFilters : IOperationFilter
{

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null) operation.Parameters = new List<OpenApiParameter>();

        var methodName = context.MethodInfo.Name;

        if (methodName != null && methodName.Equals("GetListingsAsync"))
        {
            var properties = typeof(GetListingsQueryParams).GetProperties();
            foreach (var property in properties)
            {
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = property.Name.ToSnakeCase(),
                    In = ParameterLocation.Query
                });
            }
        }
    }
}