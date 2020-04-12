🚧 README: in develpment 🚧
🚧 Project status: in research/development 🚧
# PlantIO
\# Organic friendly agriculture API
\# Distributed

🚧  

## Building
### System requirements
- [.NETCore SDK > 3.1.201](https://dotnet.microsoft.com/download/dotnet-core/3.1)
Can be installed from ZIP file referenced on [install script](https://dotnet.microsoft.com/download/dotnet-core/scripts). Must set environment variables
- [GIT](https://git-scm.com/downloads)
- [NodeJS/npm ](https://www.npmjs.com/get-npm)

#### Portable .NET Core Setup Script (optional)
⚠️ for reference, use with care ⚠️
```batch
echo off
set currentFolder=%~dp0
echo FOLDER:%currentFolder%

set DOTNET_ROOT=%currentFolder%dotnetcore
set DOTNET_INSTALL_DIR=%dotNetInstallDir%
REM TODO: check if needs both PATHs
set PATH=%PATH%;%currentFolder%dotnetcore
set PATH=%PATH%;%currentFolder%dotnetcore\dotnet.exe

pause
```

### Commands
```
cd src\api\dotnetcore
dotnet build plantIO.sln
```

# 🚧 Disclaimer 
⚠️ Graduation project. This repository is **experimental** with educational purposes and has a lighter ruleset. 

The code style and architecture used in this repository are not necessarily the same as I would use to code on other projects.