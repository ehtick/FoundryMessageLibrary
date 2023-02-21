https://dev.azure.com/iobt/IoBTNuGet/

nuget locals all -list
nuget locals global-packages -list

nuget locals global-packages -clear

https://dev.azure.com/iobt/IoBTNuGet/_artifacts/feed/IoBTMessageLibrary

dotnet pack
nuget.exe restore
nuget.exe push -Source "IoBTMessageLibrary" -ApiKey az bin\Release\IoBTMessageLibrary.7.9.0.nupkg
