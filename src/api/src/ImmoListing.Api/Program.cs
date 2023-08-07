using ImmoListing.Api.Endpoints;
using ImmoListing.Api.Json;
using ImmoListing.Api.Swagger;

using ImmoListing.Business.Extensions;
using ImmoListing.Data.Extensions;

using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SchemaFilter<SnakeCaseSchemaFilter>();
});

builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));

builder.Services.ConfigureHttpJsonOptions(option =>
{
    option.SerializerOptions.PropertyNamingPolicy = new SnakeCaseNamingPolicy();
});

builder.AddDatabase();

var app = builder.Build();

app.MigrateDatabaseIfContainer();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Container"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();
