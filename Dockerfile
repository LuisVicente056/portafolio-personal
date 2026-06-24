# 1. Etapa de ejecución (Base con etiqueta específica de Linux)
FROM mcr.microsoft.com/dotnet/aspnet:10.0-bookworm-slim AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# 2. Etapa de compilación (SDK con etiqueta específica de Linux)
FROM mcr.microsoft.com/dotnet/sdk:10.0-bookworm AS build
WORKDIR /src
COPY ["Portafolio/Portafolio.csproj", "Portafolio/"]
RUN dotnet restore "Portafolio/Portafolio.csproj"
COPY . .
WORKDIR "/src/Portafolio"
RUN dotnet build "Portafolio.csproj" -c Release -o /app/build

# 3. Etapa de publicación
FROM build AS publish
RUN dotnet publish "Portafolio.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 4. Configuración final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Portafolio.dll"]