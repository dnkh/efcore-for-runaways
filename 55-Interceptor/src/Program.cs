#region usings
using Microsoft.EntityFrameworkCore;
using Data;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
#endregion

#region dbsetup
int sqlCount = 0;
var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlite($"Data Source=blogsystemdb55.db")
    //.AddInterceptors(new SetCreatedByInterceptor())
    //.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BlogSystemDb55;Trusted_Connection=True;")
    //.UseLazyLoadingProxies() // Aktiviert Lazy Loading
    .LogTo(log =>
    {
        Console.WriteLine(log);
        if (Regex.IsMatch(log, @"Executed DbCommand"))
        {
            sqlCount++;
        }
    }, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors()
    .Options
    ;
using var db = new AppDbContext(options);
db.Database.EnsureDeleted();
db.Database.EnsureCreated();


// Seed initial ausführen, falls leer
DbSeeder.Seed(db);
#endregion

Console.WriteLine("BlogSystem Console Demo gestartet.");
// Endlosschleife zum Testen
while (true)
{
    Console.WriteLine("Testlauf gestartet...");
    sqlCount = 0;

    var stopwatch = Stopwatch.StartNew();
    var blogs = db.Blogs

        .Include(b => b.Posts)
        .Where(b => b.Id == 1)
        .ToList();

    Console.WriteLine($"Es sind {blogs.Count} Blogs verfügbar");
    foreach (var blog in blogs)
    {
        Console.WriteLine($"Blog: {blog.Name}, Url: {blog.Url}");
        foreach (var post in blog.Posts)
        {
            Console.WriteLine($"  Post: {post.Title}, CreatedBy: {post.CreatedBy}");
        }
    }
    
    var blog1 = blogs.Single(b => b.Id == 1);
    var post1 = blog1.Posts.Single(p => p.Id == 1);
    post1.CreatedBy = "User1";
    db.SaveChanges();

    Console.WriteLine($"Post1 wurde von {post1.CreatedBy} ersstellt");

    stopwatch.Stop();

#region output
    Console.WriteLine();
    Console.WriteLine($"Dauer: {stopwatch.Elapsed}");
    Console.WriteLine($"Anzahl SQL-Kommandos: {sqlCount}");
    Console.WriteLine("Drücke Enter für den nächsten Lauf...");
    Console.ReadLine();
#endregion
}
