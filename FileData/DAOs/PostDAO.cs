using Domain.Models;
using FileData.DAOInterfaces;
using Shared.DTOs;
// ReSharper disable InconsistentNaming

namespace FileData.DAOs;

public class PostDAO : IPostDAO
{
    private readonly FileContext _context;

    public PostDAO(FileContext context)
    {
        _context = context;
    }

    public Task<Post> CreatePostAsync(Post post)
    {
        int id = 1;
        if (_context.Posts!.Any())
        {
            id = _context.Posts!.Max(t => t.Id);
            id++;
        }

        post.Id = id;

        _context.Posts!.Add(post);
        _context.SaveChanges();

        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetPostsAsync(SearchPostOverviewParametersDTO searchOverviewParameters)
    {
        IEnumerable<Post> result = _context.Posts!.AsEnumerable();
        return Task.FromResult(result);
    }

    public Task UpdateAsync(Post post)
    {
        throw new NotImplementedException();
    }

    public Task<Post?> GetPostByIdAsync(int postId)
    {
        IEnumerable<Post> result = _context.Posts!.AsEnumerable();
        return Task.FromResult(result.First(p => p.Id == postId))!;
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}