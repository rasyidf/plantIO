﻿Project status: 🚧 in research/development/paused/open-for-grabs/needs-review   

# PlantIO
\# Organic-friendly AgriCulture API  
\# Multiple distributions: on private clouds / as a service / hybrid / (portable?)

This project aims to deliver an open-source cultivar catalog to assist the farmer on cultivar choice.

## [Taxonomy](Entities\Domains\Taxonomy\README.MD)
- Overview
    - Entities (Taxonomic Code, Taxonomic Methodology, Taxon, Grouping Taxon, Rank Hierarchy, Species)
    - Data (SQL/EF)  

Taxonomy deals with nomenclature and classification, assigning a unit identifier (Taxon) to groupings of beings.  
Taxon members can share common characteristics and/or ancestor, depending on the taxonomic code and methodology being considered.  
In this API context, Taxon can also have bound metadata concerning:
- botanical characteristics (morphology, phenology, etc);
- plant life cycles
- ecological interactions with fauna taxon, flora taxon, soil, environment, etc 
- cultivation characteristics
- agroeconomical characteristics    
- ...

The goal of this module is to support both cladistic and rank-based classification systems in parallel:
    - Rank-based: International Code of Nomenclature for Cultivated Plants (ICNCP).  
    - Cladistic: Phylocode.
    - Customizable "Folk Taxonomy" used for seed exchange and in-farm experiments.

This module is not for academic catalog purposes, but data can be imported/consumed from this kind of database.  

## Botany / Cultivar 🚧 
- Overview
    - Entities (Cultivar, Cultivar Characteristic)
        - Data
            - EF/SQL (structural metadata)
            - review: noSQL plants "profile" documents, from different datasets and regions (this can also be historic data)

Taxon metadata:
- plant life cycles (can be defined by taxonomic families, clades, species, variety, etc... for instance: Angiospermae has flowers)
- "casting some level of shadow", "contribution to soil structure", "association with other plants", "association with nitrogen fixing bacteria" and so on
- Allowing to associate those informations with each phase of the plant cycle

# Project structure

- Cultivar/Botany 🚧
    
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

## 🚧 Disclaimers
Graduation project ⚠️ This repository is **experimental** and has educational 🏫 and 📚 research purposes. It will follow a flexible and simplistic ruleset until release.  

The code style and architecture used in this repository are not necessarily the same as I would use to code on other projects. 

Also, this is the first application I start from scratch using **CORE** version of .NET/ASP/EF  

🚧 READMEs in develpment (sections may be moved to its own directories linked in this README with a brief introduction, commands or instructions)  
🚧 Many READMEs texts and links will have their content moved to WIKI.  
🚧 The READMEs will contain a brief overview and links to WIKI  