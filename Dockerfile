FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Ydb.Posgresql.Example/Ydb.Posgresql.Example.csproj", "Ydb.Posgresql.Example/"]
RUN dotnet restore "Ydb.Posgresql.Example/Ydb.Posgresql.Example.csproj"
COPY . .
WORKDIR "/src/Ydb.Posgresql.Example"
RUN dotnet build "Ydb.Posgresql.Example.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ydb.Posgresql.Example.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ydb.Posgresql.Example.dll"]
