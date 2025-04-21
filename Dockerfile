# STEP 1: Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy csproj and restore dependencies
COPY . .
RUN dotnet publish -c Release -o out

# STEP 2: Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .

# Set the entry point to run the app
ENTRYPOINT ["dotnet", "ProductAPI.dll"]

