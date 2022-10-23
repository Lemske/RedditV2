using Domain.Models;
using FileData.DAOInterfaces;

namespace FileData.DAOs;

public class UserFileDAO : IAuthDAO
{
    private readonly FileContext _context;

    public UserFileDAO(FileContext context)
    {
        _context = context;
    }

    public Task<User?> GetByUsernameAsync(string username)
    {
        User? existing = _context.Users.FirstOrDefault(u =>
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
        );
        return Task.FromResult(existing);
    }

    public Task CreateUserAsync(User newUser)
    {
        _context.Users.Add(newUser);
        _context.SaveChanges();
        
        return Task.CompletedTask;
    }
}