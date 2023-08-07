FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY src/ImmoListing.Api/*.csproj ./src/ImmoListing.Api/
COPY src/ImmoListing.Core/*.csproj ./src/ImmoListing.Core/
COPY src/ImmoListing.Business/*.csproj ./src/ImmoListing.Business/
COPY src/ImmoListing.Data/*.csproj ./src/ImmoListing.Data/
COPY tests/ImmoListing.Business.UnitTests/*.csproj ./tests/ImmoListing.Business.UnitTests/
COPY *.sln ./
RUN dotnet restore

# Copy everything else and build
COPY src/ ./
RUN dotnet publish ./ImmoListing.Api/ImmoListing.Api.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "ImmoListing.Api.dll"]