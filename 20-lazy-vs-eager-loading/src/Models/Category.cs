namespace Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
