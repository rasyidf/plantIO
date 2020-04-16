# 🚧
# Introduction

## Architecture

- PlantIO.Core
    - Entities
        - [Cultivar](Entities\Cultivar\README.MD)
            - Taxonomy
            - Phenology
    
    - Data
        - EF/SQL (ranks / taxonomy) #todo:(clades)
        - noSQL (clades / taxonomy) #todo: #review:

- PlantIO.History/PlantIO.Projection
    - Entities
    - Data
        - EF/SQL (structured report data?, etc)
        - noSQL: MongoDB, neDB (records)

- PlantIO.Spatial
    - Entities
        - x

🚧 subdomains are kept in the same projects but may be splited if it becomes evident and necessary

# WIKI - Coding style
* Infrastructure folders are namespaced using default namespace of its project, except for very specific technology-related or subdomain cases.
* ```[Flag]``` Enums are named with plural form

## Comment tags
For convenience and practicity, at least until "release 1", the code may contain the following comment tags:  
- #TODO: something to be done
- #techdebt: something that needs to be refactored
- #review: pull-request review comment, or something that needs to be discussed

## Member ordering

### Method styling

#### Parameters

- order:
    - keys first
    - infrastructure and context last
    - in some cases context can be first
