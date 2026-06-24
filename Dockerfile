FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["Portafolio/Portafolio/Portafolio.csproj", "Portafolio/Portafolio/"]
RUN dotnet restore "Portafolio/Portafolio/Portafolio.csproj"

COPY . .

WORKDIR "/src/Portafolio/Portafolio"

RUN dotnet build "Portafolio.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Portafolio.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Portafolio.dll"]