LABEL org.opencontainers.image.source="https://github.com/MadWorldNL/StrixAluco"

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Build.props", "MadWorldNL.StrixAluco.Server.Controllers.Web/"]
COPY ["src/MadWorldNL.StrixAluco.Server.Controllers.Web/Server.Controllers.Web.csproj", "MadWorldNL.StrixAluco.Server.Controllers.Web/"]
RUN dotnet restore "MadWorldNL.StrixAluco.Server.Controllers.Web/Server.Controllers.Web.csproj"
COPY ["src/MadWorldNL.StrixAluco.Server.Controllers.Web/", "MadWorldNL.StrixAluco.Server.Controllers.Web/"]
WORKDIR "/src/MadWorldNL.StrixAluco.Server.Controllers.Web"
RUN dotnet build "Server.Controllers.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Server.Controllers.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MadWorldNL.StrixAluco.Server.Controllers.Web.dll"]
