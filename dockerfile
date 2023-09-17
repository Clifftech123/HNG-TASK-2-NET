# Use the .NET Core SDK image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env


# Set the working directory to /app
WORKDIR /app

# Copy the .csproj file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code and build the application
COPY . ./
RUN dotnet publish -c Release -o out

# Use the .NET Core runtime image as the final environment
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final-env

# Set the working directory to /app
WORKDIR /app

# Copy the published application from the build environment to the final environment
COPY --from=build-env /app/out ./

# Expose ports 80 and 443 for the application
EXPOSE 80
EXPOSE 443

# Set the entry point for the application
ENTRYPOINT ["dotnet", "WebApplication.dll"]