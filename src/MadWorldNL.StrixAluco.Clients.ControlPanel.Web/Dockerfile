FROM --platform=$BUILDPLATFORM nginx:latest AS base
ARG BUILDPLATFORM
EXPOSE 80
EXPOSE 443

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILDPLATFORM

WORKDIR /src
COPY ["Directory.Build.props", "MadWorldNL.StrixAluco.Clients.ControlPanel.Web/"]
COPY ["src/MadWorldNL.StrixAluco.Clients.ControlPanel.Web/Clients.ControlPanel.Web.csproj", "MadWorldNL.StrixAluco.Clients.ControlPanel.Web/"]
RUN dotnet restore "MadWorldNL.StrixAluco.Clients.ControlPanel.Web/Clients.ControlPanel.Web.csproj"
COPY ["src/MadWorldNL.StrixAluco.Clients.ControlPanel.Web/", "MadWorldNL.StrixAluco.Clients.ControlPanel.Web/"]

WORKDIR "/src/MadWorldNL.StrixAluco.Clients.ControlPanel.Web/"
RUN dotnet build "Clients.ControlPanel.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Clients.ControlPanel.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
LABEL org.opencontainers.image.source="https://github.com/MadWorldNL/StrixAluco"

COPY --from=publish /app/publish/wwwroot /usr/share/nginx/html