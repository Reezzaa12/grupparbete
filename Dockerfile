FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

COPY personnummer/bin/Debug/net8.0/personnummer.dll .
COPY personnummer/bin/Debug/net8.0/personnummer.runtimeconfig.json .

CMD ["dotnet", "personnummer.dll"]
