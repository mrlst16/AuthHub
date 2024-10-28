#project to pack
$project="AuthHub.Models"
#desired version of the nuget package
$version = "1.1.2"

#Get the location/directory of the folder in which the call was made, we will navigate back to this later
$orginalLocation = Get-Location
$originalDirectory = [Environment]::CurrentDirectory

#the path to navigate to
$projectPath = "$orginalLocation\$project\"

#give some output
Write "Origin Location: $orginalLocation"
Write "Origin Directory: $originalDirectory"
Write "Project: $project"
Write "Package version: $version"
Write "Project Path: $projectPath"

#in order to pack, we must be in the specific project folder
cd "$projectPath"
[System.IO.Directory]::SetCurrentDirectory($projectPath)

pwd

#pack the project
dotnet pack p:PackageVersion=$version



#Go back to the original location/directory of this script call
cd $orginalLocation
[System.IO.Directory]::SetCurrentDirectory($originalDirectory)
