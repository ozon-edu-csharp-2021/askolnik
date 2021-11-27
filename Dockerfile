FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src
COPY ["src/MerchApi/MerchApi.csproj", "src/MerchApi/"]
RUN dotnet restore "src/MerchApi/MerchApi.csproj"

COPY . .
WORKDIR "/src/src/MerchApi"
RUN dotnet build "MerchApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MerchApi.csproj" -c Release -o /app/publish
COPY "entrypoint.sh" "/app/publish/."

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
EXPOSE 80

FROM runtime AS final
WORKDIR /app

COPY --from=publish /app/publish .

RUN chmod +x entrypoint.sh
CMD /bin/bash entrypoint.sh