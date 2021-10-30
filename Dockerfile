FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/MerchApi/MerchApi.csproj", "src/MerchApi/"]
RUN dotnet restore "src/MerchApi/MerchApi.csproj"
COPY . .
WORKDIR "/src/src/MerchApi"
RUN dotnet build "MerchApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MerchApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MerchApi.dll"]