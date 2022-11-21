namespace Domain.Models;

public class User
{
    public int Id { get; set; }//Bruger ikke ligenu
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Domain { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public int Age { get; set; }
    public int SecurityLevel { get; set; }
    
    public User(string username, string password, string email, string domain, string name, string role, int age, int securityLevel)
    {
        Username = username;
        Password = password;
        Email = email;
        Domain = domain;
        Name = name;
        Role = role;
        Age = age;
        SecurityLevel = securityLevel;
    }

    private User()
    {
    }
}