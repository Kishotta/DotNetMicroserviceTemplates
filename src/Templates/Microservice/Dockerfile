FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App

# Copy csproj files
COPY Microservice.Api/*.csproj ./Microservice.Api/
COPY Microservice.Application/*.csproj ./Microservice.Application/
COPY Microservice.Domain/*.csproj ./Microservice.Domain/
COPY Microservice.Infrastructure/*.csproj ./Microservice.Infrastructure/
COPY Microservice.Persistence/*.csproj ./Microservice.Persistence/
COPY Microservice.Presentation/*.csproj ./Microservice.Presentation/

# Restore as distinct layers
RUN dotnet restore Microservice.Api/Microservice.Api.csproj
RUN dotnet restore Microservice.Application/Microservice.Application.csproj
RUN dotnet restore Microservice.Domain/Microservice.Domain.csproj
RUN dotnet restore Microservice.Infrastructure/Microservice.Infrastructure.csproj
RUN dotnet restore Microservice.Persistence/Microservice.Persistence.csproj
RUN dotnet restore Microservice.Presentation/Microservice.Presentation.csproj

# Copy everything else and build
COPY Microservice.Api/. ./Microservice.Api/
COPY Microservice.Application/. ./Microservice.Application/
COPY Microservice.Domain/. ./Microservice.Domain/
COPY Microservice.Infrastructure/. ./Microservice.Infrastructure/
COPY Microservice.Persistence/. ./Microservice.Persistence/
COPY Microservice.Presentation/. ./Microservice.Presentation/

# Build and publish a release
WORKDIR /App/Microservice.Api
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
COPY --from=build-env /App/Microservice.Api/out .
ENTRYPOINT ["dotnet", "Microservice.Api.dll"]
