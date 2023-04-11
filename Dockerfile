# Use the official .NET 6 SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory
WORKDIR /src

# Copy the .sln (solution) file and .csproj (project) files
COPY *.sln ./
COPY AttendanceRegister.WebApi/AttendanceRegister.WebApi.csproj AttendanceRegister.WebApi/
COPY AttendanceRegister.BLL/AttendanceRegister.BLL.csproj AttendanceRegister.BLL/
COPY Attendanceregister.DAL/Attendanceregister.DAL.csproj Attendanceregister.DAL/

# Restore the NuGet packages
RUN dotnet restore

# Copy the rest of the application source code
COPY . .

# Build the application in Release mode
RUN dotnet publish -c Release -o /app

# Use the official .NET 6 runtime image as the final image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Set the working directory
WORKDIR /app

# Copy the published files from the build image
COPY --from=build /app .

# Start the application
ENTRYPOINT ["dotnet", "AttendanceRegister.WebApi.dll"]
