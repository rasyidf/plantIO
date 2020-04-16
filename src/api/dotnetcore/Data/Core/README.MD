# Technical-debts #technical-debt #td #review:
- Repository domain-specific methods will only be created when the entity set is a *known* candidate to be stored on noSQL, otherwise a generic repository exposing IQueryable<> will be used.  

#review: primary keys and indexes

- SQL Server Primary Key vs. Clustered Index: Part 1
By: Mike Byrd
http://logicalread.com/sql-server-primary-key-vs-clustered-index-part-1-mb01/
https://logicalread.com/2012/11/12/sql-server-primary-key-vs-clustered-index-part-2-mb01/

- https://dba.stackexchange.com/questions/50708/do-natural-keys-provide-higher-or-lower-performance-in-sql-server-than-surrogate/50709#50709

- https://medium.com/fintechexplained/clustered-vs-non-clustered-index-8efed55ed7b9

Column DataSetId queries:  
📢 https://use-the-index-luke.com/sql/where-clause/the-equals-operator/concatenated-keys  
📢 https://www.cockroachlabs.com/docs/stable/indexes.html#best-practices  