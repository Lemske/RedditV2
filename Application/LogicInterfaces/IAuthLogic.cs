using Domain.Models;

namespace Application.LogicInterfaces;

public interface IAuthLogic
{
    public Task<User> ValidateUserAsync(string username, string password);
    public Task RegisterUser(string username, string password, string email, string name, int age);
}