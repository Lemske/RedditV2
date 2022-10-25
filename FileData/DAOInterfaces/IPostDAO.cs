using Domain.Models;

namespace FileData.DAOInterfaces;

public interface IPostDAO
{
    Task<Post> CreateAsync(Post post);
    Task<IEnumerable<Post>> GetAsync();
    Task UpdateAsync(Post post);
    Task<Post?> GetByIdAsync(int todoId);
    Task DeleteAsync(int id);
}