#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./QuotesService/QuotesService/QuotesService.csproj", "/src"]
RUN dotnet restore "QuotesService.csproj"
COPY "./QuotesService/QuotesService" "/src"
WORKDIR "/src"
RUN dotnet build "QuotesService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QuotesService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QuotesService.dll"]