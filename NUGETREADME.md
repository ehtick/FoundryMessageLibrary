https://dev.azure.com/iobt/IoBTNuGet/

nuget locals all -list
nuget locals global-packages -list

nuget locals global-packages -clear

https://dev.azure.com/iobt/IoBTNuGet/_artifacts/feed/IoBTMessageLibrary

set environment variables for 

dotnet pack
nuget.exe restore
nuget.exe push -Source "IoBTMessageLibrary" -ApiKey OUR_API_KEY bin\Release\IoBTMessageLibrary.7.9.4.nupkg
