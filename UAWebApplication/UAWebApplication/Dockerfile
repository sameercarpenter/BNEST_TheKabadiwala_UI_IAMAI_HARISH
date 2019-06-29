FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["UAWebApplication/UAWebApplication.csproj", "UAWebApplication/"]
RUN dotnet restore "UAWebApplication/UAWebApplication.csproj"
COPY . .
WORKDIR "/src/UAWebApplication"
RUN dotnet build "UAWebApplication.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "UAWebApplication.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "UAWebApplication.dll"]