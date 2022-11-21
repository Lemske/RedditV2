using Domain.Models;
using FileData.DAOInterfaces;
// ReSharper disable InconsistentNaming

namespace FileData.DAOs;

public class UserFileDAO : IAuthDAO
{
    private readonly RedditContext _context;

    public UserFileDAO(RedditContext context)
    {
        _context = context;
    }

    public Task<User?> GetByUsernameAsync(string username)
    {
        return Task.FromResult(_context.Users!.FirstOrDefault(u =>
            u.Username.ToLower().Equals(username.ToLower())
        ));
    }

    public Task CreateUserAsync(User newUser)
    {
        _context.Users!.Add(newUser);
        _context.SaveChanges();
        
        return Task.CompletedTask;
    }
}