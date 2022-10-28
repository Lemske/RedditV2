using Domain.Models;
using Shared.DTOs;

namespace WebAPI.Services;

public interface IAuthService
{
    Task<User> ValidateUserAsync(UserLoginDTO userLoginDto);
    Task RegisterUserAsync(UserRegisterDTO userRegisterDto);
}