using Domain.Models;
using Shared.DTOs;

namespace FileData.DAOInterfaces;

public interface IPostDAO
{
    Task<Post> CreateAsync(Post post);
    Task<IEnumerable<Post>> GetAsync(SearchPostOverviewParametersDTO searchOverviewParameters);
    Task UpdateAsync(Post post);
    Task<Post?> GetByIdAsync(int postId);
    Task DeleteAsync(int id);
}