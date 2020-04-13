# Introduction

# WIKI - Coding style

* Infrastructure folders are namespaced using default namespace of its project, except for very specific technology-related or subdomain cases.

## Member ordering

### Method styling

#### Parameters

- order:
    - keys first
    - infrastructure and context last
    - in some cases context can be first (TODO: further explain)

### DataBase

Column DataSetId:  
📢 https://use-the-index-luke.com/sql/where-clause/the-equals-operator/concatenated-keys  
📢 https://www.cockroachlabs.com/docs/stable/indexes.html#best-practices  