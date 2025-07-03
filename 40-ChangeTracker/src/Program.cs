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
    .UseSqlite($"Data Source=blogsystemdb40.db")
    //.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BlogSystemDb40;Trusted_Connection=True;")
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
//db.Database.EnsureDeleted();
db.Database.EnsureCreated();


// Seed initial ausführen, falls leer
//DbSeeder.Seed(db);
#endregion

Console.WriteLine("BlogSystem Console Demo gestartet.");
// Endlosschleife zum Testen
while (true)
{
    Console.WriteLine("Testlauf gestartet...");
    sqlCount = 0;

    var stopwatch = Stopwatch.StartNew();
    
     var blogs = db.Blogs
        //.Include(b => b.Posts)
            //.ThenInclude(p => p.Category)
        //.Include(b => b.Posts)
            //.ThenInclude(p => p.Comments)
        //.AsNoTracking()
        .ToList();
    

    /*
         var blogs = db.Blogs
         .Select(b => new
         {
             b.Id,
             b.Name,
             Posts = b.Posts.Select(p => new
             {
                 p.Id,
                 p.Title,
                 Category = p.Category.Name,
                 Comments = p.Comments.Select(c => new { c.Id, c.Content })
             }).ToList()
         })
        .ToList();
    */
    stopwatch.Stop();

#region output
    Console.WriteLine();
    Console.WriteLine($"Dauer: {stopwatch.Elapsed}");
    Console.WriteLine($"Anzahl SQL-Kommandos: {sqlCount}");
    Console.WriteLine("Drücke Enter für den nächsten Lauf...");
    Console.ReadLine();
#endregion
}
