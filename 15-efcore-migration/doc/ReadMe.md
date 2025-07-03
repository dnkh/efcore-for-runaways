# Initial Version
This is the initial version of the project which is the base for the upcoming demos

## Commands
```csharp
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

## EFBunde
Um ein Bundle zu erstellen welches komplett Selfhosted ist und auch in einem Docker Container ausgeführt werden kann. Muss man folgenden Befehl ausführen

```csharp
dotnet ef migrations bundle --self-contained -r linux-x64
```

