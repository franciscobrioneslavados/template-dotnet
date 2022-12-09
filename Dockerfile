FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore WebApi/
RUN dotnet clean WebApi/
# Build and publish a release
RUN dotnet publish WebApi/ -c Release -o out --os linux --arch x64

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
COPY --from=build-env /App/out .

ENV ASPNETCORE_URLS=http://+:80/

EXPOSE 80

ENTRYPOINT ["dotnet", "WebApi.dll"]