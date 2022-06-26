FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build-env
WORKDIR /app

# Copy Everything
COPY . ./

# Restore as distinct layers
RUN dotnet restore

# Build libraries
RUN dotnet publish src/Xyz.Core -c Release -o out/Xyz.Core/
RUN dotnet publish src/Xyz.Multitenancy -c Release -o out/Xyz.Multitenancy/
RUN dotnet publish src/Xyz.Infrastructure -c Release -o out/Xyz.Infrastructure/
RUN dotnet publish src/Xyz.Api -c Release -o out/Xyz.Api/

# Copy over lib json files
COPY src/Xyz.Infrastructure/*.json out/Xyz.Infrastructure/
COPY src/Xyz.Multitenancy/*.json out/Xyz.Multitenancy/

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal
WORKDIR /app
COPY --from=build-env /app/out .

# EXPOSE 5000

# CMD ["ls -la", "/app/out"]
ENTRYPOINT ["dotnet", "Xyz.Api/Xyz.Api.dll"]
