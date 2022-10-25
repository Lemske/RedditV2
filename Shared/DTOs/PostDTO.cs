namespace Shared.DTOs;

public class PostDTO
{
    public string Owner { get; }
    public string Title { get; }
    public string Topic { get; set;}
    
    public ICollection<CommentDTO> Comments { get; set;}


    public PostDTO(string owner, string title, string topic)
    {
        Owner = owner;
        Title = title;
        Topic = topic;
    }
}