#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Sht.url.Api/Sht.url.Api.csproj", "Sht.url.Api/"]
RUN dotnet restore "Sht.url.Api/Sht.url.Api.csproj"
COPY . .
WORKDIR "/src/Sht.url.Api"
RUN dotnet build "Sht.url.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sht.url.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sht.url.Api.dll"]
