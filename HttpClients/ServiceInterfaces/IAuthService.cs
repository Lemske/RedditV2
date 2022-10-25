using System.Security.Claims;
using Shared.DTOs;

namespace HttpClients.ServiceInterfaces;

public interface IAuthService
{
    public Task LoginAsync(UserLoginDTO userLoginDto);
    public Task LogoutAsync();
    public Task RegisterAsync(UserRegisterDTO userRegisterDto);
    public Task<ClaimsPrincipal> GetAuthAsync();
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
}