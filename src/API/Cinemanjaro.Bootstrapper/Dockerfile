#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Cinemanjaro.Bootstrapper/Cinemanjaro.Bootstrapper.csproj", "Cinemanjaro.Bootstrapper/"]
COPY ["Cinemanjaro.Common/Cinemanjaro.Common.csproj", "Cinemanjaro.Common/"]
COPY ["Modules/Movies/Cinemanjaro.Movies.API/Cinemanjaro.Movies.API.csproj", "Modules/Movies/Cinemanjaro.Movies.API/"]
COPY ["Modules/Movies/Cinemanjaro.Movies.Core/Cinemanjaro.Movies.Core.csproj", "Modules/Movies/Cinemanjaro.Movies.Core/"]
COPY ["Modules/Shows/Cinemanjaro.Shows.API/Cinemanjaro.Shows.API.csproj", "Modules/Shows/Cinemanjaro.Shows.API/"]
COPY ["Modules/Shows/Cinemanjaro.Shows.Application/Cinemanjaro.Shows.Application.csproj", "Modules/Shows/Cinemanjaro.Shows.Application/"]
COPY ["Modules/Shows/Cinemanjaro.Shows.Domain/Cinemanjaro.Shows.Domain.csproj", "Modules/Shows/Cinemanjaro.Shows.Domain/"]
COPY ["Modules/Shows/Cinemanjaro.Shows.Shared/Cinemanjaro.Shows.Shared.csproj", "Modules/Shows/Cinemanjaro.Shows.Shared/"]
COPY ["Modules/Shows/Cinemanjaro.Shows.Infrastructure/Cinemanjaro.Shows.Infrastructure.csproj", "Modules/Shows/Cinemanjaro.Shows.Infrastructure/"]
COPY ["Modules/Tickets/Cinemanjaro.Tickets.API/Cinemanjaro.Tickets.API.csproj", "Modules/Tickets/Cinemanjaro.Tickets.API/"]
COPY ["Modules/Tickets/Cinemanjaro.Tickets.Application/Cinemanjaro.Tickets.Application.csproj", "Modules/Tickets/Cinemanjaro.Tickets.Application/"]
COPY ["Modules/Tickets/Cinemanjaro.Tickets.Domain/Cinemanjaro.Tickets.Domain.csproj", "Modules/Tickets/Cinemanjaro.Tickets.Domain/"]
COPY ["Modules/Tickets/Cinemanjaro.Tickets.Infrastructure/Cinemanjaro.Tickets.Infrastructure.csproj", "Modules/Tickets/Cinemanjaro.Tickets.Infrastructure/"]
COPY ["Modules/Users/Cinemanjaro.Users.API/Cinemanjaro.Users.API.csproj", "Modules/Users/Cinemanjaro.Users.API/"]
COPY ["Modules/Users/Cinemanjaro.Users.Core/Cinemanjaro.Users.Core.csproj", "Modules/Users/Cinemanjaro.Users.Core/"]
RUN dotnet restore "Cinemanjaro.Bootstrapper/Cinemanjaro.Bootstrapper.csproj"
COPY . .
WORKDIR "/src/Cinemanjaro.Bootstrapper"
RUN dotnet build "Cinemanjaro.Bootstrapper.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cinemanjaro.Bootstrapper.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cinemanjaro.Bootstrapper.dll"]