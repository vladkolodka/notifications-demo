#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Server/Demo.ApiServer/Demo.ApiServer.csproj", "Server/Demo.ApiServer/"]
COPY ["Server/Demo.Infrastructure/Demo.Infrastructure.csproj", "Server/Demo.Infrastructure/"]
COPY ["Server/Demo.Notifications/Demo.Notifications.csproj", "Server/Demo.Notifications/"]
RUN dotnet restore "Server/Demo.ApiServer/Demo.ApiServer.csproj"
COPY . .
WORKDIR "/src/Server/Demo.ApiServer"
RUN dotnet build "Demo.ApiServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Demo.ApiServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Demo.ApiServer.dll"]
