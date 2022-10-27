namespace Shared.DTOs;

public class SearchPostOverviewParametersDTO
{
    public int? PostID { get; set; }
    public string? Topic { get; set; }

    public SearchPostOverviewParametersDTO(int? postId, string? topic)
    {
        PostID = postId;
        Topic = topic;
    }
}