FROM mcr.microsoft.com/dotnet/sdk:9.0
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish

EXPOSE 5000
ENTRYPOINT [ "dotnet", "./bin/Release/net9.0/publish/2-api-with-db.dll" ]