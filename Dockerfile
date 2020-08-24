FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY src/CasinoGame/CasinoGame.API/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY src/CasinoGame/. ./
RUN dotnet publish -c Release ./CasinoGame.API/

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/CasinoGame.API .
ENTRYPOINT ["dotnet", "CasinoGame.API.dll"]