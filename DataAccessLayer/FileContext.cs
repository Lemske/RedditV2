using System.Text.Json;
using Domain.Models;

namespace DataAccessLayer;

public class FileContext
{
    private const string FilePath = "data.json";
    private DataContainer? _dataContainer;

    public ICollection<User>? Users
    {
        get
        {
            LoadData();
            return _dataContainer!.Users;
        }
    }
    
    public ICollection<Post>? Posts
    {
        get
        {
            LoadData();
            return _dataContainer!.Posts;
        }
    }
    
    private void LoadData()
    {
        if (_dataContainer != null) return;
        
        if (!File.Exists(FilePath))
        {
            _dataContainer = new ()
            {
                Users = new List<User>
                {
                    new User("trmo", "onetwo3FOUR","trmo@via.dk", "via", "Troels Mortensen", "Teacher", 36, 4)
                    ,
                    new User("jknr", "gmail", "jakob@gmail.com", "gmail","Jakob Rasmussen", "Student",34, 2)
                },
                Posts = new List<Post>()
            };
            return;
        }
        string content = File.ReadAllText(FilePath);
        _dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }
    
    public void SaveChanges()
    {
        string serialized = JsonSerializer.Serialize(_dataContainer, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(FilePath, serialized);
        _dataContainer = null;
    }
}