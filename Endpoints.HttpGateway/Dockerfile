FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Endpoints.HttpGateway/Endpoints.HttpGateway.csproj", "Endpoints.HttpGateway/"]
RUN dotnet restore "Endpoints.HttpGateway/Endpoints.HttpGateway.csproj"
COPY . .
WORKDIR "/src/Endpoints.HttpGateway"
RUN dotnet build "Endpoints.HttpGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Endpoints.HttpGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Endpoints.HttpGateway.dll"] 