# Get base SDK Iamge from Microsoft
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

#Copy the CSPROJ file and restore any dependencies (Via NUGET)
COPY *.csproj ./
RUN dotnet restore

#Copy the project files and build or release
COPY . ./
RUN dotnet publish -c release -o out

#Generate runtime image
FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "InterLab.API.dll"]