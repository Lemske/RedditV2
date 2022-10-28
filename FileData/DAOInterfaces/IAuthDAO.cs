using Domain.Models;

namespace FileData.DAOInterfaces;

// ReSharper disable once InconsistentNaming
public interface IAuthDAO
{
    Task<User?> GetByUsernameAsync(string username);
    Task CreateUserAsync(User newUser);
}