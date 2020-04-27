# 🚧
# Introduction

🚧 #todo: subdomains are currently in the same projects but there are plans to make a taxonomy.sln (or even a new GitHub project)

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

## Technical-debt:

- on Debug.Assert() calls, use code contracts, Nullable Reference Types or some other parameter check utility
