using Domain.Models;
using Shared.DTOs;

namespace Application.LogicInterfaces;

public interface IAuthLogic
{
    public Task<User> ValidateUserAsync(UserLoginDTO userLoginDto);
    public Task RegisterUserAsync(UserRegisterDTO userRegisterDto);
}