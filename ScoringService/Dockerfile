﻿FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ScoringService.csproj", "."]
RUN dotnet restore "ScoringService.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ScoringService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ScoringService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ScoringService.dll"]
