using Domain.Models;

namespace FileData.DAOInterfaces;

public interface IAuthDAO
{
    Task<User?> GetByUsernameAsync(string username);
    Task CreateUserAsync(User newUser);
}