namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public User Owner { get; private set; }
    public string Title { get; private set; }
    
    public string Topic { get; set;}
    
    //public ICollection<Comment> Comments { get; set;}


    public Post(User owner, string title, string topic)
    {
        Owner = owner;
        Title = title;
        Topic = topic;
    }

    private Post()
    {
    }
}