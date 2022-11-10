FROM mcr.microsoft.com/dotnet/aspnet as base
WORKDIR /build
COPY /bin .
ENTRYPOINT [ "build/net6.0/publish/AuthHub.dll" ]