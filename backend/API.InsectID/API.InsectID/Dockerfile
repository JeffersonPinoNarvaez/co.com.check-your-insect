#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ARG envName=Development
ENV ASPNETCORE_ENVIRONMENT="${envName}"
ENV DOTNET_USE_POLLING_FILE_WATCHER=1
ENV NUGET_PACKAGES=/.nuget/fallbackpackages2
ENV NUGET_FALLBACK_PACKAGES=/.nuget/fallbackpackages;/.nuget/fallbackpackages2
ENV PATH=/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin
ENV APP_UID=1654
ENV ASPNETCORE_HTTP_PORTS=80
ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV DOTNET_VERSION=6.0.0
ENV ASPNET_VERSION=6.0.0
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["API.InsectID/API.InsectID.csproj", "API.InsectID/"]
COPY ["APIInsectID.Domain/APIInsectID.Domain.csproj", "APIInsectID.Domain/"]
COPY ["APIInsectID.Application/APIInsectID.Application.csproj", "APIInsectID.Application/"]
COPY ["APIInsectID.Infrastructure/APIInsectID.Infrastructure.csproj", "APIInsectID.Infrastructure/"]

RUN dotnet restore "API.InsectID/API.InsectID.csproj"
COPY . .
WORKDIR "/src/API.InsectID"
RUN dotnet build "API.InsectID.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "API.InsectID.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.InsectID.dll"]