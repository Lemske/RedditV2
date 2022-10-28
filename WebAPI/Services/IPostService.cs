using Shared.DTOs;

namespace WebAPI.Services;

public interface IPostService
{
    Task<PostDTO> CreatePostAsync(PostCreationDTO dto);
    Task<IEnumerable<PostOverviewDTO>> GetPostOverviewAsync(SearchPostOverviewParametersDTO searchOverviewParameters);
    Task<PostDTO> GetPostByIdAsync(int id);
    //Task DeleteAsync(int id);
}