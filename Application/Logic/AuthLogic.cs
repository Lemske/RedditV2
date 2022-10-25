using System.ComponentModel.DataAnnotations;
using Application.LogicInterfaces;
using Domain.Models;
using FileData.DAOInterfaces;
using Shared.DTOs;

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

    public async Task<User> ValidateUserAsync(UserLoginDTO userLoginDto)
    {
        User? existingUser = _authDao.GetByUsernameAsync(userLoginDto.Username).Result;
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }
        if (!existingUser.Password.Equals(userLoginDto.Password))
        {
            throw new Exception("Password mismatch");
        }
        return existingUser;
    }

    public async Task RegisterUser(UserRegisterDTO userRegisterDto) //Hvis tid, se om dette ikke kan gøres smartere
    {
        if (userRegisterDto.Username.Length < UserLengthCondition)
            throw new ValidationException($"Username can't < {UserLengthCondition}");
        if (_authDao.GetByUsernameAsync(userRegisterDto.Username).Result != null)
            throw new ValidationException("Username already in use");
        if (userRegisterDto.Password.Length < PasswordLengthCondition)
            throw new ValidationException($"Password can't be null or < {PasswordLengthCondition}");
        if (userRegisterDto.Email.Length < EmailLengthCondition)
            throw new ValidationException($"Email can't be null or < {EmailLengthCondition}");
        if (userRegisterDto.Age < AgeSizeCondition)
            throw new ValidationException($"Age can't be under {AgeSizeCondition}");
        
        await _authDao.CreateUserAsync(new User()
        {
            Username = userRegisterDto.Username,
            Password = userRegisterDto.Password,
            Email = userRegisterDto.Email,
            Name = userRegisterDto.Name,
            Age = userRegisterDto.Age,
            Domain = "Reddit",
            Role = "Wizard",
            SecurityLevel = 1
        });
    }
}