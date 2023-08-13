using ImmoListing.Core.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ImmoListing.Api.Swagger;

public class SnakeCaseParameterFilter : IParameterFilter
{
    public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
    {
        if (parameter.Name == null) return;

        parameter.Name = parameter.Name.ToSnakeCase();
    }
}