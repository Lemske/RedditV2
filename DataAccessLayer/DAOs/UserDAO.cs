using DataAccessLayer.DAOInterfaces;
using Domain.Models;

// ReSharper disable InconsistentNaming

namespace DataAccessLayer.DAOs;

public class UserDAO : IAuthDAO
{
    private readonly RedditContext _context;

    public UserDAO(RedditContext context)
    {
        _context = context;
    }

    public Task<User?> GetByUsernameAsync(string username)
    {
        return Task.FromResult(_context.Users.FirstOrDefault(u =>
            u.Username.ToLower().Equals(username.ToLower())
        ));
    }

    public Task CreateUserAsync(User newUser)
    {
        _context.Users.Add(newUser);
        _context.SaveChanges();
        
        return Task.CompletedTask;
    }
}