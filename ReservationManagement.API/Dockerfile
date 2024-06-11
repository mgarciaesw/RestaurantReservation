#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8280
EXPOSE 8281

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ReservationManagement.API/ReservationManagement.API.csproj", "ReservationManagement.API/"]
COPY ["ReservationManagement.Application/ReservationManagement.Application.csproj", "ReservationManagement.Application/"]
COPY ["ReservationManagement.Domain/ReservationManagement.Domain.csproj", "ReservationManagement.Domain/"]
COPY ["RestaurantReservation.Core.Domain/RestaurantReservation.Core.Domain.csproj", "RestaurantReservation.Core.Domain/"]
COPY ["ReservationManagement.Infrastructure/ReservationManagement.Infrastructure.csproj", "ReservationManagement.Infrastructure/"]
RUN dotnet restore "./ReservationManagement.API/./ReservationManagement.API.csproj"
COPY . .
WORKDIR "/src/ReservationManagement.API"
RUN dotnet build "./ReservationManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ReservationManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReservationManagement.API.dll"]