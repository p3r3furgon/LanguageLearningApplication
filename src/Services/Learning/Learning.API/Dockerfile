#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/Learning/Learning.API/Learning.API.csproj", "src/Services/Learning/Learning.API/"]
COPY ["src/Services/Learning/Learning.Application/Learning.Application.csproj", "src/Services/Learning/Learning.Application/"]
COPY ["src/Services/Learning/Learning.DataAccess/Learning.DataAccess.csproj", "src/Services/Learning/Learning.DataAccess/"]
COPY ["src/CommonFiles/CommonFiles/CommonFiles.csproj", "src/CommonFiles/CommonFiles/"]
COPY ["src/Services/Learning/Learning.Domain/Learning.Domain.csproj", "src/Services/Learning/Learning.Domain/"]
COPY ["src/Services/Learning/Learning.Infrastructure/Learning.Infrastructure.csproj", "src/Services/Learning/Learning.Infrastructure/"]
RUN dotnet restore "./src/Services/Learning/Learning.API/Learning.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Learning/Learning.API"
RUN dotnet build "./Learning.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Learning.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Learning.API.dll"]