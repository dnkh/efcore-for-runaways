
using Models;

namespace Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext db)
    {
        if (db.Blogs.Any())
            return;

        var categories = new[]
        {
            new Category { Name = "EF Core" },
            new Category { Name = "C#" },
            new Category { Name = "Dotnet" },
            new Category { Name = "Architecture" }
        };

        var blogs = new List<Blog>();

        for (int i = 1; i <= 10; i++)
        {
            var blog = new Blog
            {
                Name = $"Blog {i}",
                Url = $"https://blog{i}.example.com",
                Posts = new List<Post>()
            };

            for (int j = 1; j <= 100; j++)
            {
                var category = categories[(i + j) % categories.Length];

                blog.Posts.Add(new Post
                {
                    Title = $"Post {j} from Blog {i}",
                    Content = $"This is the content of post {j} from blog {i}.",
                    PublishedAt = DateTime.UtcNow.AddDays(-j),
                    Category = category,
                    Comments = new List<Comment>
                    {
                        new Comment { Author = "Alice", Content = "Great post!", CreatedAt = DateTime.UtcNow },
                        new Comment { Author = "Bob", Content = "Very helpful, thanks!", CreatedAt = DateTime.UtcNow },
						new Comment { Author = "Peter", Content = "Nice idea", CreatedAt = DateTime.UtcNow },
                        new Comment { Author = "Marry", Content = "Sounds good!", CreatedAt = DateTime.UtcNow }
                    }
                });
            }

            blogs.Add(blog);
        }

        db.Categories.AddRange(categories);
        db.Blogs.AddRange(blogs);
        db.SaveChanges();
    }
}
