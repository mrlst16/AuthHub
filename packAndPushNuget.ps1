#project to pack
$project="AuthHub.Models"
#desired version of the nuget package
$version = "1.1.0"

#Get the location of the folder in which the call was made, we will navigate back to this later
$orginalLocation = Get-Location
#the path to navigate to
$projectPath = "$orginalLocation\$project"

#give some output
Write "Origin: $orginalLocation"
Write "Project: $project"
Write "Package version: $version"
Write "Project Path: $projectPath"

#in order to pack, we must be in the specific project folder
cd "$projectPath"

$currentLocation = Get-Location

Write "Current Location: $currentLocation"

#pack the project
dotnet pack p:PackageVersion=$version



#Go back to the original location of this script call
cd $orginalLocation