FROM --platform=$BUILDPLATFORM nginx:latest AS base
ARG BUILDPLATFORM
EXPOSE 80
EXPOSE 443

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILDPLATFORM

WORKDIR /src
COPY ["Directory.Build.props", "MadWorldNL.StrixAluco.Clients.Hub.Web/"]
COPY ["src/MadWorldNL.StrixAluco.Clients.Hub.Web/Clients.Hub.Web.csproj", "MadWorldNL.StrixAluco.Clients.Hub.Web/"]
RUN dotnet restore "MadWorldNL.StrixAluco.Clients.Hub.Web/Clients.Hub.Web.csproj"
COPY ["src/MadWorldNL.StrixAluco.Clients.Hub.Web/", "MadWorldNL.StrixAluco.Clients.Hub.Web/"]

WORKDIR "/src/MadWorldNL.StrixAluco.Clients.Hub.Web/"
RUN dotnet build "Clients.Hub.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Clients.Hub.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
COPY --from=publish /app/publish/wwwroot /usr/share/nginx/html