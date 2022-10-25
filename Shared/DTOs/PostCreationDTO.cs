namespace Shared.DTOs;

public class PostCreationDTO
{
    public string OwnerUsername { get; }
    public string Title { get; }
    public string Topic { get; }
    
    public PostCreationDTO(string ownerUsername, string title, string topic)
    {
        OwnerUsername = ownerUsername;
        Title = title;
        Topic = topic;
    }
}