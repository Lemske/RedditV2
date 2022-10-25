using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using HttpClients.ServiceInterfaces;
using Shared.DTOs;

namespace HttpClients.Services;

public class PostService : IPostService
{
    private readonly HttpClient _client;

    public PostService(HttpClient client)
    {
        this._client = client;
    }
    
    public async Task<PostDTO> CreateAsync(PostCreationDTO dto)
    {
        string postAsJson = JsonSerializer.Serialize(dto);
        
        StringContent content = new(postAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _client.PostAsJsonAsync("https://localhost:7073/Post/create", dto);
        string responceContent = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responceContent);
        }
        
        PostDTO postDto = JsonSerializer.Deserialize<PostDTO>(responceContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return postDto;
    }

    public Task<ICollection<PostDTO>> GetAsync(string? userName, int? userId, bool? completedStatus, string? titleContains)
    {
        throw new NotImplementedException();
    }
}