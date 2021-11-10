#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-buster-slim AS build

ARG CONFIGURATION=Release

WORKDIR /src
COPY ["TranslationSystemService/TranslationSystemService.csproj", "TranslationSystemService/"]
RUN dotnet restore "TranslationSystemService/TranslationSystemService.csproj"
COPY . .
WORKDIR "/src/TranslationSystemService"
RUN dotnet build "TranslationSystemService.csproj" -c $CONFIGURATION -o /app/build

FROM build AS publish

ARG CONFIGURATION=Release

RUN dotnet publish "TranslationSystemService.csproj" -c $CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tilde.MT.TranslationSystemService.dll"]