using Application.LogicInterfaces;
using Domain.Models;
using Shared.DTOs;

namespace WebAPI.Services;

public class AuthService : IAuthService
{
    private IAuthLogic _logic;

    public AuthService(IAuthLogic logic)
    {
        _logic = logic;
    }

    public Task<User> ValidateUser(UserLoginDTO userLoginDto)
    {
        return _logic.ValidateUserAsync(userLoginDto.Username, userLoginDto.Password);
    }

    public Task RegisterUser(UserRegisterDTO userRegisterDto)
    {
        _logic.RegisterUser(userRegisterDto.Username, userRegisterDto.Password, userRegisterDto.Email,
            userRegisterDto.Name, userRegisterDto.Age);
        return Task.CompletedTask;
    }
}