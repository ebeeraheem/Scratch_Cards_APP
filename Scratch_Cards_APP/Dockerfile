#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Scratch_Cards_APP/Scratch_Cards_APP.csproj", "Scratch_Cards_APP/"]
RUN dotnet restore "./Scratch_Cards_APP/Scratch_Cards_APP.csproj"
COPY . .
WORKDIR "/src/Scratch_Cards_APP"
RUN dotnet build "./Scratch_Cards_APP.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Scratch_Cards_APP.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Scratch_Cards_APP.dll"]