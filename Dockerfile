FROM amazon/aws-cli:latest as awscli
RUN aws configure import --csv file://aws_credentials.csv

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App
COPY . ./
ENV PATH="${PATH}:/root/.dotnet/tools"

RUN dotnet tool install -g AWS.CodeArtifact.NuGet.CredentialProvider
RUN dotnet codeartifact-creds install
RUN dotnet nuget add source "https://mattylantz-477439744462.d.codeartifact.us-east-2.amazonaws.com/nuget/MattyLantz/v3/index.json" -n "AWSCodeArtifact"

RUN dotnet publish -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT [ "build/net6.0/publish/AuthHub.dll" ]