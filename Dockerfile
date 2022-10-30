FROM mcr.microsoft.com/dotnet/aspnet as base
WORKDIR /build
COPY AuthHub.Api/bin/Debug/ .
ENTRYPOINT [ "build/AuthHub.dll" ]