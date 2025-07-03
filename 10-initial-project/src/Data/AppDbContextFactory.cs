using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite("Data Source=blogsystemdb10.db");
        //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BlogSystemDb10;Trusted_Connection=True;");

        return new AppDbContext(optionsBuilder.Options);
    }
}
