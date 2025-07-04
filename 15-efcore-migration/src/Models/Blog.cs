namespace Models;

public class Blog
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    //public string Description { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
