#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MT5_API/MT5_API.csproj", "MT5_API/"]
RUN dotnet restore "MT5_API/MT5_API.csproj"
COPY . .
WORKDIR "/src/MT5_API"
RUN dotnet build "MT5_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MT5_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MT5_API.dll"]

#FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim-arm64v8 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim-arm64v8 AS build
#WORKDIR /src
#COPY ["MT5_API/MT5_API.csproj", "MT5_API/"]
#RUN dotnet restore "MT5_API/MT5_API.csproj" -r linux-arm
#COPY . .
#WORKDIR "/src/MT5_API"
#RUN dotnet build "MT5_API.csproj" -c Release -o /app/build -r linux-arm64
#
#FROM build AS publish
#RUN dotnet publish "MT5_API.csproj" -c Release -o /app/publish -r linux-arm64
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "MT5_API.dll"]