using System.Text.Json;
using Domain.Models;

namespace FileData;

public class FileContext
{
    private const string FilePath = "data.json";
    private DataContainer? _dataContainer;

    public ICollection<User> Users
    {
        get
        {
            LoadData();
            return _dataContainer!.Users;
        }
    }
    
    public ICollection<Post> Posts
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
                    new User
                    {
                        Age = 36,
                        Email = "trmo@via.dk",
                        Domain = "via",
                        Name = "Troels Mortensen",
                        Password = "onetwo3FOUR",
                        Role = "Teacher",
                        Username = "trmo",
                        SecurityLevel = 4
                    },
                    new User
                    {
                        Age = 34,
                        Email = "jakob@gmail.com",
                        Domain = "gmail",
                        Name = "Jakob Rasmussen",
                        Password = "password",
                        Role = "Student",
                        Username = "jknr",
                        SecurityLevel = 2
                    }
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