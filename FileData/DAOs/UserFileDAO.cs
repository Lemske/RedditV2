using Domain.Models;
using FileData.DAOInterfaces;
// ReSharper disable InconsistentNaming

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
        return Task.FromResult(_context.Users!.FirstOrDefault(u =>
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
        ));
    }

    public Task CreateUserAsync(User newUser)
    {
        _context.Users!.Add(newUser);
        _context.SaveChanges();
        
        return Task.CompletedTask;
    }
}