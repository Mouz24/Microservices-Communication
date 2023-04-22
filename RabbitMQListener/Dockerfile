#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RabbitMQListener/RabbitMQListener.csproj", "RabbitMQListener/"]
RUN dotnet restore "RabbitMQListener/RabbitMQListener.csproj"
COPY . .
WORKDIR "/src/RabbitMQListener"
RUN dotnet build "RabbitMQListener.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RabbitMQListener.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RabbitMQListener.dll"]