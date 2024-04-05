FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 7179

ENV ASPNETCORE_URLS=http://+:7179
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["RentAndDelivery.API/RentAndDelivery.API.csproj", "RentAndDelivery.API/"]
COPY ["RentAndDelivery.CrossCutting/RentAndDelivery.CrossCutting.csproj", "RentAndDelivery.CrossCutting/"]
COPY ["RentAndDelivery.Application/RentAndDelivery.Application.csproj", "RentAndDelivery.Application/"]
COPY ["RentAndDelivery.Domain/RentAndDelivery.Domain.csproj", "RentAndDelivery.Domain/"]
COPY ["RentAndDelivery.Infrastructure/RentAndDelivery.Infrastructure.csproj", "RentAndDelivery.Infrastructure/"]
RUN dotnet restore "RentAndDelivery.API/RentAndDelivery.API.csproj"
COPY . .
WORKDIR "/src/RentAndDelivery.API"
RUN dotnet build "RentAndDelivery.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RentAndDelivery.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RentAndDelivery.API.dll"]