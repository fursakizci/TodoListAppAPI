# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory to /app
WORKDIR /app

# Copy the solution and project files
COPY *.sln ./
COPY TodoListApp.API/*.csproj ./TodoListApp.API/
COPY TodoListApp.Business/*.csproj ./TodoListApp.Business/
COPY TodoListApp.DataLayer/*.csproj ./TodoListApp.DataLayer/
COPY TodoListApp.Entities/*.csproj ./TodoListApp.Entities/

# Restore the dependencies
RUN dotnet restore

# Copy the rest of the application code
COPY . .

# Build the application
RUN dotnet publish -c Release -o out

# Use the official ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory to /app
WORKDIR /app

# Copy the built application from the build image
COPY --from=build /app/out .

# Expose port 80
EXPOSE 80

# Define the entry point for the container
ENTRYPOINT ["dotnet", "TodoListApp.API.dll"]
