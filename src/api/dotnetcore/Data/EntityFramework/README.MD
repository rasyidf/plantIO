
```batch
dotnet ef migrations add Initial --project Data\EntityFramework\Data.EF.csproj
```


# Technical-debts #technical-debt #td
- Repositories with domain specific methods will only be done when the entity set is a *known* candidate to be stored on noSQL, otherwise a generic repository will be used. 

At this moment, all will use generic repository exposing IQueryable<>.