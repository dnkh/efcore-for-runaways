
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

        modelBuilder.Entity<Blog>()
            .Property(b => b.Name)
            .HasMaxLength(200)
            .IsRequired();

        modelBuilder.Entity<Post>()
            .Property(p => p.Title)
            .HasMaxLength(300)
            .IsRequired();

        // modelBuilder.Entity<Post>()
        //     .OwnsOne(p => p.MetaData, meta =>
        //     {
        //         meta.Property(m => m.CreatedAt).HasColumnName("CreatedAt");
        //         meta.Property(m => m.ChangedAt).HasColumnName("ChangedAt");
        //         meta.Property(m => m.CreatedBy).HasColumnName("CreatedBy");
        //         meta.Property(m => m.ChangedBy).HasColumnName("ChangedBy");
        //     });


        modelBuilder.Entity<Category>()
            .Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();
    }
}
