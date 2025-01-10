FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Remi.AIBuddy/Remi.AIBuddy.csproj", "Remi.AIBuddy/"]
RUN dotnet restore "Remi.AIBuddy/Remi.AIBuddy.csproj"
COPY . .
WORKDIR "/src/Remi.AIBuddy"
RUN dotnet build "Remi.AIBuddy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Remi.AIBuddy.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Remi.AIBuddy.dll"]
