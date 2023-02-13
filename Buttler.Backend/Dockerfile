FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY "Buttler.API/Buttler.API.csproj" "Buttler.API/"
COPY "Buttler.Domain/Buttler.Domain.csproj" "Buttler.Domain/"
COPY "Buttler.Logic/Buttler.Logic.csproj" "Buttler.Logic/"
COPY "Buttler.Data/Buttler.Data.csproj" "Buttler.Data/"
RUN dotnet restore "Buttler.API/Buttler.API.csproj"
COPY . .
WORKDIR "/src/Buttler.API"
RUN dotnet build "Buttler.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Buttler.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Buttler.API.dll"]
EXPOSE 5157
