using Domain.Models;
using Shared.DTOs;
// ReSharper disable InconsistentNaming

namespace FileData.DAOInterfaces;

public interface IPostDAO
{
    Task<Post> CreatePostAsync(Post post);
    Task<IEnumerable<Post>> GetPostsAsync(SearchPostOverviewParametersDTO searchOverviewParameters);
    //Task UpdateAsync(Post post);
    Task<Post?> GetPostByIdAsync(int postId);
    //Task DeleteAsync(int id);
}