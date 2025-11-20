FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BookHub.csproj", "."]
RUN dotnet restore "BookHub.csproj"
COPY . .
RUN dotnet publish "BookHub.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://*:$PORT
EXPOSE 8080
ENTRYPOINT ["dotnet", "BookHub.dll"]