using Domain.Models;
using Shared.DTOs;

namespace WebAPI.Services;

public interface IAuthService
{
    Task<User> ValidateUser(UserLoginDTO userLoginDto);
    Task RegisterUser(UserRegisterDTO userRegisterDto);
}