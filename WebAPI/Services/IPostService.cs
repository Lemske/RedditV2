using Domain.Models;
using Shared.DTOs;

namespace WebAPI.Services;

public interface IPostService
{
    Task<PostDTO> CreateAsync(PostCreationDTO dto);
    Task<IEnumerable<Post>> GetAsync(SeachPostParaneterDTO searchParameters);
    Task DeleteAsync(int id);
}