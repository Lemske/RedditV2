using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Application.LogicInterfaces;
using Domain.Models;
using Shared.DTOs;

namespace WebAPI.Services;

public class AuthService : IAuthService //Ved ikke om jeg vil have denne klasse sender model objekter videre. Kan argumentere for og imod
{
    private IAuthLogic _logic;

    public AuthService(IAuthLogic logic)
    {
        _logic = logic;
    }

    public Task<User> ValidateUser(UserLoginDTO userLoginDto)
    {
        NullCheck(userLoginDto);
        return _logic.ValidateUserAsync(userLoginDto);
    }

    public Task RegisterUser(UserRegisterDTO userRegisterDto)
    {
        NullCheck(userRegisterDto);
        return _logic.RegisterUser(userRegisterDto);
    }

    private void NullCheck(Object dto)
    {
        foreach (PropertyInfo prop in dto.GetType().GetProperties())
        {
            if(prop.GetValue(dto, null) == null)
                throw new ValidationException(prop.Name + " cannot be null");
        }
    }
}