namespace Shared.DTOs;

public class PostOverviewDTO
{
    public int Id { get; }
    public string Title { get; }
    public string Username { get; }

    public PostOverviewDTO(int id, string title, string username)
    {
        Id = id;
        Title = title;
        Username = username;
    }
}