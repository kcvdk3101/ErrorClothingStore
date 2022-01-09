FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ErrorClothingStore.API/ErrorClothingStore.API.csproj", "ErrorClothingStore.API/"]
COPY ["ErrorClothingStore.Application/ErrorClothingStore.Application.csproj", "ErrorClothingStore.Application/"]
COPY ["ErrorClothingStore.Domain/ErrorClothingStore.Domain.csproj", "ErrorClothingStore.Domain/"]
COPY ["ErrorClothingStore.Persistence/ErrorClothingStore.Persistence.csproj", "ErrorClothingStore.Persistence/"]
RUN dotnet restore "ErrorClothingStore.API/ErrorClothingStore.API.csproj"
COPY . .
WORKDIR "/src/ErrorClothingStore.API"
RUN dotnet build "ErrorClothingStore.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ErrorClothingStore.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ErrorClothingStore.API.dll"]
