# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /source

# Copy Everything
COPY . ./

# Restore as distinct layers
RUN dotnet restore --disable-parallel

# Build libraries
RUN dotnet publish -c Release -o out --no-restore


# Run Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /source/out .

EXPOSE 5000

ENTRYPOINT ["dotnet", "Xyz.Api.dll"]
