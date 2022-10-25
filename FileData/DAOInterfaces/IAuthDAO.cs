using Domain.Models;
using Shared.DTOs;

namespace FileData.DAOInterfaces;

public interface IAuthDAO
{
    Task<User?> GetByUsernameAsync(string username);
    Task CreateUserAsync(User newUser);
}