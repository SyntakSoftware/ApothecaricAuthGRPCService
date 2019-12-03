FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Apothecaric.Authentication.Service/Apothecaric.Authentication.Service.csproj", "Apothecaric.Authentication.Service/"]
RUN dotnet restore "Apothecaric.Authentication.Service/Apothecaric.Authentication.Service.csproj"
COPY . .
WORKDIR "/src/Apothecaric.Authentication.Service"
RUN dotnet build "Apothecaric.Authentication.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Apothecaric.Authentication.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Apothecaric.Authentication.Service.dll"]