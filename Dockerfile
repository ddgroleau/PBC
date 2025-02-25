FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Server/Recipebot.Server.csproj", "Server/"]
RUN dotnet restore "Server/Recipebot.Server.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "Recipebot.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Recipebot.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Recipebot.Server.dll"]