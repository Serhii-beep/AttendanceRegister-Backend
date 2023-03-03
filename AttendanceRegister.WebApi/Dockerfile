#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AttendanceRegister.WebApi/AttendanceRegister.WebApi.csproj", "AttendanceRegister.WebApi/"]
COPY ["AttendanceRegister.BLL/AttendanceRegister.BLL.csproj", "AttendanceRegister.BLL/"]
COPY ["Attendanceregister.DAL/Attendanceregister.DAL.csproj", "Attendanceregister.DAL/"]
RUN dotnet restore "AttendanceRegister.WebApi/AttendanceRegister.WebApi.csproj"
COPY . .
WORKDIR "/src/AttendanceRegister.WebApi"
RUN dotnet build "AttendanceRegister.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AttendanceRegister.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AttendanceRegister.WebApi.dll"]