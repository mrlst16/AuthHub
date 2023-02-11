FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App
COPY . ./
COPY nuget.config ./
ENV PATH="${PATH}:/root/.dotnet/tools"
RUN dotnet publish -c Release -o out
RUN ls

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
COPY --from=build-env App/out .
ENTRYPOINT ["dotnet", "AuthHub.Api.dll" ]