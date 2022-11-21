using Domain.Models;

namespace DataAccessLayer;

public class DataContainer
{
    public ICollection<User>? Users { get; set; }
    public ICollection<Post>? Posts { get; set; }
}