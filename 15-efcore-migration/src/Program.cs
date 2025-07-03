
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
    .UseSqlite($"Data Source=blogsystemdb15.db")
    //.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BlogSystemDb15;Trusted_Connection=True;")
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
db.Database.EnsureCreated();


// Seed initial ausführen, falls leer
DbSeeder.Seed(db);

#endregion

Console.WriteLine("BlogSystem Console Demo gestartet.");

// Endlosschleife zum Testen
while (true)
{
    Console.Clear();
    Console.WriteLine("Testlauf gestartet...");
    sqlCount = 0;

    var stopwatch = Stopwatch.StartNew();

    var blogs = db.Blogs
        .ToList();

    stopwatch.Stop();

    foreach (var blog in blogs)
    {
        Console.WriteLine($"> {blog.Name} ({blog.Posts.Count} Posts)");
    }

#region output
    Console.WriteLine();
    Console.WriteLine($"Dauer: {stopwatch.Elapsed}");
    Console.WriteLine($"Anzahl SQL-Kommandos: {sqlCount}");
    Console.WriteLine("Drücke Enter für den nächsten Lauf...");
    Console.ReadLine();
#endregion
}
