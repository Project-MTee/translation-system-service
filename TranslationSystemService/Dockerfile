#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build

ARG CONFIGURATION=Release

# For build version extraction
RUN apt update && apt install -y mono-utils

WORKDIR /src
COPY ["TranslationSystemService/TranslationSystemService.csproj", "TranslationSystemService/"]
RUN dotnet restore "TranslationSystemService/TranslationSystemService.csproj"
COPY . .
WORKDIR "/src/TranslationSystemService"
RUN dotnet build "TranslationSystemService.csproj" -c $CONFIGURATION -o /app/build

FROM build AS publish

ARG CONFIGURATION=Release

RUN dotnet publish "TranslationSystemService.csproj" -c $CONFIGURATION -o /app/publish

# Extract build version for service
RUN monodis --assembly /app/publish/Tilde.MT.TranslationSystemService.dll | grep Version | awk -F ' ' '{print $2}' > /app/publish/version.txt

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tilde.MT.TranslationSystemService.dll"]