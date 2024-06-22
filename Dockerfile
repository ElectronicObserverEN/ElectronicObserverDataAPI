#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
RUN chown -R app /app
EXPOSE 8080
EXPOSE 8081

FROM --platform=linux/arm64 mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ElectronicObserverDataAPI/ElectronicObserverDataAPI.csproj", "ElectronicObserverDataAPI/"]
RUN dotnet restore "./ElectronicObserverDataAPI/ElectronicObserverDataAPI.csproj"
COPY . .
WORKDIR "/src/ElectronicObserverDataAPI"
RUN dotnet build "./ElectronicObserverDataAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ElectronicObserverDataAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ElectronicObserverDataAPI.dll"]