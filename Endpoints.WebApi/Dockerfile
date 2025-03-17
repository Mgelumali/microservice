FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Endpoints.WebApi/Endpoints.WebApi.csproj", "Endpoints.WebApi/"]
RUN dotnet restore "Endpoints.WebApi/Endpoints.WebApi.csproj"
COPY . .
WORKDIR "/src/Endpoints.WebApi"
RUN dotnet build "Endpoints.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Endpoints.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Endpoints.WebApi.dll"] 