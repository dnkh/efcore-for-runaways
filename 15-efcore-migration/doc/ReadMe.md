# Initial Version
This is the initial version of the project which is the base for the upcoming demos

## Commands
```pwsh
dotnet tool install --global dotnet-ef
```


## Codechanges
### BlogSystem.csproj

```csharp
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.0" />
```

### Data/AppDbContextFactory

```csharp
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite("Data Source=blogsystemdb15.sql");

        return new AppDbContext(optionsBuilder.Options);
    }
}
```

## Migrations

```pwsh
dotnet ef migrations add "Initial Migrationsm"    

dotnet ef database update
````




## EFBunde
Um ein Bundle zu erstellen welches komplett "self contained" ist und auch in einem Docker Container ausgeführt werden kann. Muss man folgenden Befehl ausführen

```pwsh
dotnet ef migrations bundle --self-contained -r linux-x64

dotnet ef migrations bundle --self-contained -r win-x64
```

Verfügbare Runtime Ids finden sich unter 
([https://learn.microsoft.com/en-us/dotnet/core/rid-catalog#known-rids](https://learn.microsoft.com/en-us/dotnet/core/rid-catalog#known-rids))

