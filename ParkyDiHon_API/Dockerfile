#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ParkyDiHon_API/ParkyDiHon_API.csproj", "ParkyDiHon_API/"]
RUN dotnet restore "ParkyDiHon_API/ParkyDiHon_API.csproj"
COPY . .
WORKDIR "/src/ParkyDiHon_API"
RUN dotnet build "ParkyDiHon_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ParkyDiHon_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ParkyDiHon_API.dll"]