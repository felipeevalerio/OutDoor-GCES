# Use the official Microsoft .NET SDK as a base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the project files into the container
COPY . .

# Build the application
RUN dotnet publish -c Release -o out

# Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Set the working directory inside the container
WORKDIR /app

# Copy the published output from the build image
COPY --from=build /app/out .
# Expose the port the app will run on
EXPOSE 8080

# Set the entry point for the application
ENTRYPOINT ["dotnet", "Outdoor-API.dll"]