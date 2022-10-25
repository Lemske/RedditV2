using Domain.Models;
using FileData.DAOInterfaces;

namespace FileData.DAOs;

public class PostDAO : IPostDAO
{
    private readonly FileContext _context;

    public PostDAO(FileContext context)
    {
        _context = context;
    }

    public Task<Post> CreateAsync(Post post)
    {
        int id = 1;
        if (_context.Posts.Any())
        {
            id = _context.Posts.Max(t => t.Id);
            id++;
        }

        post.Id = id;

        _context.Posts.Add(post);
        _context.SaveChanges();

        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Post post)
    {
        throw new NotImplementedException();
    }

    public Task<Post?> GetByIdAsync(int todoId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}