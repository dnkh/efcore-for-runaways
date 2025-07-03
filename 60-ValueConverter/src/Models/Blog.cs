namespace Models;

public class Blog
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    //public Url Url { get; set; } = new Url(string.Empty);

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
