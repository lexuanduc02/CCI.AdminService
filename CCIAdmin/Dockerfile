#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CCIAdmin/CCIAdmin.csproj", "CCIAdmin/"]
COPY ["CCI.Service/CCI.Service.csproj", "CCI.Service/"]
COPY ["CCI.Repository/CCI.Repository.csproj", "CCI.Repository/"]
COPY ["CCI.Domain/CCI.Domain.csproj", "CCI.Domain/"]
COPY ["CCI.Common/CCI.Common.csproj", "CCI.Common/"]
COPY ["CCI.Model/CCI.Model.csproj", "CCI.Model/"]
RUN dotnet restore "CCIAdmin/CCIAdmin.csproj"
COPY . .
WORKDIR "/src/CCIAdmin"
RUN dotnet build "CCIAdmin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CCIAdmin.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CCIAdmin.dll"]