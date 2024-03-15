#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["VideogamesStore.WorkerService/VideogamesStore.WorkerService.csproj", "VideogamesStore.WorkerService/"]
RUN dotnet restore "VideogamesStore.WorkerService/VideogamesStore.WorkerService.csproj"
COPY . .
WORKDIR "/src/VideogamesStore.WorkerService"
RUN dotnet build "VideogamesStore.WorkerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VideogamesStore.WorkerService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VideogamesStore.WorkerService.dll"]