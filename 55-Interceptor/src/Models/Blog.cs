namespace Models;

public class Blog
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    //public bool IsDeleted { get; set; } = false;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
