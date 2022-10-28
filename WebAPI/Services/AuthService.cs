using Application.LogicInterfaces;
using Domain.Models;
using Shared.DTOs;
using WebAPI.Services.ServiceParent;

namespace WebAPI.Services;

public class AuthService : NullCheckService, IAuthService //Ved ikke om jeg vil have denne klasse sender model objekter videre. Kan argumentere for og imod
{
    private readonly IAuthLogic _authLogic;

    public AuthService(IAuthLogic authLogic)
    {
        _authLogic = authLogic;
    }

    public Task<User> ValidateUserAsync(UserLoginDTO userLoginDto)
    {
        NullCheck(userLoginDto);
        return _authLogic.ValidateUserAsync(userLoginDto);
    }

    public Task RegisterUserAsync(UserRegisterDTO userRegisterDto)
    {
        NullCheck(userRegisterDto);
        return _authLogic.RegisterUserAsync(userRegisterDto);
    }
}