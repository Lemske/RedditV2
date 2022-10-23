using System.ComponentModel.DataAnnotations;
using Application.LogicInterfaces;
using Domain.Models;
using FileData.DAOInterfaces;

namespace Application.Logic;

public class AuthLogic : IAuthLogic
{
    private readonly IAuthDAO _authDao;

    public AuthLogic(IAuthDAO authDao)
    {
        _authDao = authDao;
    }

    public async Task<User> ValidateUserAsync(string username, string password)
    {
        User? existingUser = _authDao.GetByUsernameAsync(username).Result;
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }
        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }
        return existingUser;
    }

    public async Task RegisterUser(string username, string password, string email, string name, int age) //Hvis tid, se om dette ikke kan gøres smartere
    {
        if (string.IsNullOrEmpty(username) || username.Length < 4)
            throw new ValidationException("Username can't be null or < 4");
        if (_authDao.GetByUsernameAsync(username).Result != null)
            throw new ValidationException("Username already in use");
        if (string.IsNullOrEmpty(password) || password.Length < 6)
            throw new ValidationException("Password can't be null or < 6");
        if (string.IsNullOrEmpty(email) || email.Length < 3)
            throw new ValidationException("Email can't be null or < 3");
        if (string.IsNullOrEmpty(name))
            throw new ValidationException("Username can't be null");
        if (age < 18)
            throw new ValidationException("Age can't be under 18");

        User newUser = new()
        {
            Username = username,
            Password = password,
            Email = email,
            Name = name,
            Age = age,
            Domain = "Reddit",
            Role = "Wizard",
            SecurityLevel = 1
        };
        await _authDao.CreateUserAsync(newUser);
    }
}