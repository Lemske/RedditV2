using System.ComponentModel.DataAnnotations;
using Application.LogicInterfaces;
using Domain.Models;
using FileData.DAOInterfaces;

namespace Application.Logic;

public class AuthLogic : IAuthLogic
{
    private readonly IAuthDAO _authDao;

    private const int UserLengthCondition = 4; //Kan være en klasse med navnet "Conditions" i shared skulle laves, da jeg også gør tjek på server for at mindske kald over netværk
    private const int PasswordLengthCondition = 6;
    private const int EmailLengthCondition = 3;//Ikke ordenligt tjek af Email
    private const int AgeSizeCondition = 18;

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
        if (username.Length < UserLengthCondition)
            throw new ValidationException($"Username can't < {UserLengthCondition}");
        if (_authDao.GetByUsernameAsync(username).Result != null)
            throw new ValidationException("Username already in use");
        if (password.Length < PasswordLengthCondition)
            throw new ValidationException($"Password can't be null or < {PasswordLengthCondition}");
        if (email.Length < EmailLengthCondition)
            throw new ValidationException($"Email can't be null or < {EmailLengthCondition}");
        if (age < AgeSizeCondition)
            throw new ValidationException($"Age can't be under {AgeSizeCondition}");
        
        await _authDao.CreateUserAsync(new User()
        {
            Username = username,
            Password = password,
            Email = email,
            Name = name,
            Age = age,
            Domain = "Reddit",
            Role = "Wizard",
            SecurityLevel = 1
        });
    }
}