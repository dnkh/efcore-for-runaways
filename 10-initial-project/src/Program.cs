
#region using Directives
using Microsoft.EntityFrameworkCore;
using Data;
using System.Diagnostics;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
#endregion

Console.WriteLine("BlogSystem Console Demo gestartet.");

#region Database Setup
int sqlCount = 0;
var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BlogSystemDb;Trusted_Connection=True;")
    // .UseLazyLoadingProxies() // Aktiviert Lazy Loading
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
// DbSeeder.Seed(db);

#endregion

// Endlosschleife zum Testen
while (true)
{
    Console.Clear();
    Console.WriteLine("Testlauf gestartet...");
    sqlCount = 0;

    var stopwatch = Stopwatch.StartNew();

    var blogs = db.Blogs
        .Include(b => b.Posts)
        .ThenInclude(p => p.Comments)
        .ToList();

    stopwatch.Stop();

    foreach (var blog in blogs)
    {
        Console.WriteLine($"> {blog.Name}");
        foreach (var post in blog.Posts)
        {
            Console.WriteLine($"{post.Title}");
            foreach (var comment in post.Comments)
            {
                Console.WriteLine($"Author: {comment.Author}, Content: {comment.Content}, CreatedAt: {comment.CreatedAt}");
            }
        }

    }

    #region Output
    Console.WriteLine();
    Console.WriteLine($"Dauer: {stopwatch.Elapsed} ms");
    Console.WriteLine($"Anzahl SQL-Kommandos: {sqlCount}");
    Console.WriteLine("Drücke Enter für den nächsten Lauf...");
    Console.ReadLine();
    #endregion    

}
