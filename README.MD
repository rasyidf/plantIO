﻿🚧 README: in develpment 🚧  
🚧 Project status: in research/development 🚧  

# PlantIO
🚧 Project status: in research/development  
\# Organic-friendly AgriCulture API  
\# Multiple distributions: on private clouds / as a service / hybrid / (portable?)

📅 [Project Roadmap](https://github.com/davifiamenghi/plantIO/wiki/Roadmap)

🚧 READMEs in develpment (sections may be moved to its own directories linked in this README with a brief introduction, commands or instructions)
🚧 Many READMEs texts and links will have their content moved to WIKI. 
🚧 The READMEs will contain a brief overview and links to WIKI

## API (dotnetcore)

### Build

#### Commands
Ensure the working directory  is dotnetcore
```batch
cd src\api\dotnetcore
```
##### Run
```batch
dotnet run plantio.sln --project WebApi/WebApi.csproj
```
##### Build
```batch
dotnet build plantIO.sln
```

#### System requirements
- [.NETCore SDK > 3.1.201](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- [GIT](https://git-scm.com/downloads)
- [NodeJS/npm ](https://www.npmjs.com/get-npm)

##### Portable .NET Core Setup Script (optional)
.NET Core can be installed from ZIP file referenced on [install script](https://dotnet.microsoft.com/download/dotnet-core/scripts).  
Setting environment variables is necessary ⚠️ script for reference, use with care ⚠️
```batch
echo off
set currentFolder=%~dp0
echo FOLDER:%currentFolder%
set dotNetRootDir=%currentFolder%dotnetcore
set dotNetExePath=%dotNetInstallDir%\dotnet.exe

echo setting dotnet environment variables
set DOTNET_ROOT=%dotNetRootDir%
set DOTNET_INSTALL_DIR=%dotNetExePath%

REM TODO: check if needs both PATHs
echo setting PATH environment variable
set PATH=%PATH%;%dotNetRootDir% 
set PATH=%PATH%;%dotNetExePath%

pause
```

## 🚧 Disclaimer 
Graduation project ⚠️ This repository is **experimental** and has educational 🏫 and 📚 research purposes. It will follow a flexible and simplistic ruleset until release.  

The code style and architecture used in this repository are not necessarily the same as I would use to code on other projects.

Also, this is the first application I start from scratch using **CORE** version of .NET/ASP/EF  