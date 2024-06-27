#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./services/WebStore.Product.API/WebStore.Products.API.csproj", "services/WebStore.Product.API/"]
COPY ["./services/WebStore.Product.Application/WebStore.Product.Application.csproj", "services/WebStore.Product.Application/"]
COPY ["./WebStore.Core/WebStore.Core.csproj", "WebStore.Core/"]
COPY ["./WebStore.Infrastructure/WebStore.Infrastructure.csproj", "WebStore.Infrastructure/"]

RUN dotnet restore "services/WebStore.Product.API/WebStore.Products.API.csproj"
COPY . .
WORKDIR "services/WebStore.Product.API"
RUN dotnet build "WebStore.Products.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebStore.Products.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebStore.Products.API.dll"]