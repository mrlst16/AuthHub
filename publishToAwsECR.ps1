#generate the dlls
dotnet clean
dotnet restore
dotnet build
dotnet publish AuthHub

#switch to project folder
cd .\AuthHub

#push to aws
aws ecr get-login-password --region us-east-2 | docker login --username AWS --password-stdin 477439744462.dkr.ecr.us-east-2.amazonaws.com
docker build -t authhub .
docker tag authhub:latest 477439744462.dkr.ecr.us-east-2.amazonaws.com/authhub:latest
docker push 477439744462.dkr.ecr.us-east-2.amazonaws.com/authhub:latest