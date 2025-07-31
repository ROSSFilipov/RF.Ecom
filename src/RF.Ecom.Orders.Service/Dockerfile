FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/RF.Ecom.Orders.Service/RF.Ecom.Orders.Service.csproj", "src/RF.Ecom.Orders.Service/"]
COPY ["src/RF.Ecom.Core/RF.Ecom.Core.csproj", "src/RF.Ecom.Core/"]
COPY ["src/RF.Ecom.Infrastructure/RF.Ecom.Infrastructure.csproj", "src/RF.Ecom.Infrastructure/"]
RUN dotnet restore "./src/RF.Ecom.Orders.Service/RF.Ecom.Orders.Service.csproj"
COPY . .
WORKDIR "/src/src/RF.Ecom.Orders.Service"
RUN dotnet build "./RF.Ecom.Orders.Service.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RF.Ecom.Orders.Service.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RF.Ecom.Orders.Service.dll"]