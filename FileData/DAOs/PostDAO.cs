using Domain.Models;
using FileData.DAOInterfaces;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;
// ReSharper disable InconsistentNaming

namespace FileData.DAOs;

public class PostDAO : IPostDAO
{
    private readonly RedditContext _context;

    public PostDAO(RedditContext context)
    {
        _context = context;
    }

    public Task<Post> CreatePostAsync(Post post)
    {
        _context.Posts.Add(post);
        _context.SaveChanges();

        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetPostsAsync(SearchPostOverviewParametersDTO searchOverviewParameters)
    {
        IEnumerable<Post> result = _context.Posts.Include(post => post.Owner).AsQueryable();
        return Task.FromResult(result);
    }

    public Task UpdateAsync(Post post)
    {
        throw new NotImplementedException();
    }

    public Task<Post?> GetPostByIdAsync(int postId)
    {
        return Task.FromResult(_context.Posts.Include(post => post.Owner).FirstOrDefault(p => p.Id == postId));
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}