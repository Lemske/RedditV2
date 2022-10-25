namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public User Owner { get; }
    public string Title { get; }
    
    public string Topic { get; set;}
    
    public ICollection<Comment> Comments { get; set;}


    public Post(User owner, string title, string topic)
    {
        Owner = owner;
        Title = title;
        Topic = topic;
    }
}