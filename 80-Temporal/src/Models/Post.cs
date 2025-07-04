namespace Models;

public class Post
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    // public PostMetaData MetaData { get; set; } = PostMetaData.Default;
    public DateTime PublishedAt { get; set; }

    public int BlogId { get; set; }
    public virtual Blog Blog { get; set; } = null!;

    public int? CategoryId { get; set; }
    public virtual Category? Category { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
