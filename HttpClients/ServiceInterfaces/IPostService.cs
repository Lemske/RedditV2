using Shared.DTOs;

namespace HttpClients.ServiceInterfaces;

public interface IPostService
{
    Task<PostDTO> CreateAsync(PostCreationDTO dto);
    Task<IEnumerable<PostOverviewDTO>> GetAsync(SearchPostOverviewParametersDTO searchPostOverviewParametersDto);
    Task<PostDTO?> GetAsync(int postId);
}