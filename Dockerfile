#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TMS.API/TMS.API.csproj", "TMS.API/"]
COPY ["TMS.Model/TMS.Model.csproj", "TMS.Model/"]
COPY ["TMS.Common/TMS.Common.csproj", "TMS.Common/"]
COPY ["TMS.IRepository/TMS.IRepository.csproj", "TMS.IRepository/"]
COPY ["TMS.Repository/TMS.Repository.csproj", "TMS.Repository/"]
RUN dotnet restore "TMS.API/TMS.API.csproj"
COPY . .
WORKDIR "/src/TMS.API"
RUN dotnet build "TMS.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TMS.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TMS.API.dll"]