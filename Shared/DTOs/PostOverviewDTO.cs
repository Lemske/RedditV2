namespace Shared.DTOs;

public class PostOverviewDTO
{
    public int Id { get; }
    public string Title { get; }

    public PostOverviewDTO(int id, string title)
    {
        Id = id;
        Title = title;
    }
}