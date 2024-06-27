#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./services/WebStore.Identity.API/WebStore.Identity.API.csproj", "services/WebStore.Identity.API/"]
COPY ["./services/WebStore.Identity.Application/WebStore.Identity.Application.csproj", "services/WebStore.Identity.Application/"]
COPY ["./WebStore.Core/WebStore.Core.csproj", "WebStore.Core/"]
COPY ["./WebStore.Infrastructure/WebStore.Infrastructure.csproj", "WebStore.Infrastructure/"]

RUN dotnet restore "services/WebStore.Identity.API/WebStore.Identity.API.csproj"
COPY . .
WORKDIR "services/WebStore.Identity.API"
RUN dotnet build "WebStore.Identity.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebStore.Identity.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebStore.Identity.API.dll"]