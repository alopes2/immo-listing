using ImmoListing.Api.Endpoints;
using ImmoListing.Api.Json;
using ImmoListing.Api.Swagger;

using ImmoListing.Business.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SchemaFilter<SnakeCaseSchemaFilter>();
});

builder.Services.ConfigureHttpJsonOptions(option =>
{
    option.SerializerOptions.PropertyNamingPolicy = new SnakeCaseNamingPolicy();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();
