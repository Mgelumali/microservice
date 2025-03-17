FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Endpoints.Oauth/Endpoints.Oauth.csproj", "Endpoints.Oauth/"]
RUN dotnet restore "Endpoints.Oauth/Endpoints.Oauth.csproj"
COPY . .
WORKDIR "/src/Endpoints.Oauth"
RUN dotnet build "Endpoints.Oauth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Endpoints.Oauth.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Endpoints.Oauth.dll"] 