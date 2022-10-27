using Domain.Models;
using Shared.DTOs;

namespace WebAPI.Services;

public interface IPostService
{
    Task<PostDTO> CreateAsync(PostCreationDTO dto);
    Task<IEnumerable<PostOverviewDTO>> GetAsync(SearchPostOverviewParametersDTO searchOverviewParameters);
    Task<PostDTO> GetAsync(int id);
    Task DeleteAsync(int id);
}