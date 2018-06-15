FROM microsoft/aspnetcore-build:latest AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:latest AS build
WORKDIR /src
COPY Service/M4Movie_Api/M4Movie_Api.csproj Service/M4Movie_Api/
COPY Service/M4Movie.Api.Business/M4Movie.Api.Business.csproj Service/M4Movie.Api.Business/
COPY Service/M4Movie.Api.Data/M4Movie.Api.Data.csproj Service/M4Movie.Api.Data/
COPY Common/M4Movie.Api.Contracts/M4Movie.Api.Contracts.csproj Common/M4Movie.Api.Contracts/
COPY Common/M4Movie.Api.Constants/M4Movie.Api.Constants.csproj Common/M4Movie.Api.Constants/
RUN dotnet restore Service/M4Movie_Api/M4Movie_Api.csproj
COPY . ./
WORKDIR /src/Service/M4Movie_Api
RUN dotnet build M4Movie_Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish M4Movie_Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "M4Movie_Api.dll"]




