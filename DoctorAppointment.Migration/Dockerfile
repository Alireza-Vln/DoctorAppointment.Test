FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DoctorAppointment.Migrations/DoctorAppointment.Migrations.csproj", "DoctorAppointment.Migrations/"]
RUN dotnet restore "DoctorAppointment.Migrations/DoctorAppointment.Migrations.csproj"
COPY . .
WORKDIR "/src/DoctorAppointment.Migrations"
RUN dotnet build "DoctorAppointment.Migrations.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DoctorAppointment.Migrations.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DoctorAppointment.Migrations.dll"]
