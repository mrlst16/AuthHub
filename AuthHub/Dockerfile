FROM mcr.microsoft.com/dotnet/aspnet as base
WORKDIR /build
COPY bin/Debug/net6.0/publish/. .
ENTRYPOINT [ "dotnet", "AuthHub.dll" ]