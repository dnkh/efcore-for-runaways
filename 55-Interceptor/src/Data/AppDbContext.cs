
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data;

public class AppDbContext : DbContext
{
    public DbSet<Blog> Blogs => Set<Blog>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Comment> Comments => Set<Comment>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

/*
        modelBuilder.Entity<Blog>()
            .HasQueryFilter(b => !b.IsDeleted);
*/
        modelBuilder.Entity<Blog>()
            .Property(b => b.Name)
            .HasMaxLength(200)
            .IsRequired();

        modelBuilder.Entity<Post>()
            .Property(p => p.Title)
            .HasMaxLength(300)
            .IsRequired();

        modelBuilder.Entity<Category>()
            .Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();
    }
}
