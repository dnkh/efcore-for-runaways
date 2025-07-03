using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite("Data Source=blogsystemdb15.db");
        //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BlogSystemDb15;Trusted_Connection=True;");

        return new AppDbContext(optionsBuilder.Options);
    }
}
