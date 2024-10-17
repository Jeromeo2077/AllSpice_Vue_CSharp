# Use an official Node.js runtime as the base image for the client build
FROM --platform=linux/amd64 node:20-slim AS client-builder

# Set the working directory in the client builder container
WORKDIR /app/client

# Copy the client-side package.json and package-lock.json to the client builder container
COPY client/package*.json ./

# Install client application dependencies
RUN npm install

# Copy the client application source code to the client builder container
COPY client ./

# Build the client-side code
RUN npm run build

# Manually specify an amd64 arch build environment for the dotnet restore to complete
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine-amd64 AS build-env

WORKDIR /app/server

# Copy everything
COPY server/*.csproj ./

# Restore as distinct layers
RUN dotnet restore

COPY server ./
COPY --from=client-builder /app/client/docs /app/server/wwwroot

# Build and publish a release
RUN dotnet publish -c Release -o out
# If build fails here, check your /server folder for a *.sln file and delete it

# Start runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/server/out .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet allspice_vue_csharp.dll
