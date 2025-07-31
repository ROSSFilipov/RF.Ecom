FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/RF.Ecom.Mcp.Http/RF.Ecom.Mcp.Http.csproj", "src/RF.Ecom.Mcp.Http/"]
COPY ["src/RF.Ecom.Mcp.Core/RF.Ecom.Mcp.Core.csproj", "src/RF.Ecom.Mcp.Core/"]
COPY ["src/RF.Ecom.Infrastructure/RF.Ecom.Infrastructure.csproj", "src/RF.Ecom.Infrastructure/"]
RUN dotnet restore "./src/RF.Ecom.Mcp.Http/RF.Ecom.Mcp.Http.csproj"
COPY . .
WORKDIR "/src/src/RF.Ecom.Mcp.Http"
RUN dotnet build "./RF.Ecom.Mcp.Http.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RF.Ecom.Mcp.Http.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RF.Ecom.Mcp.Http.dll"]