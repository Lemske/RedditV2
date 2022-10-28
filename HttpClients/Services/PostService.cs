using System.Net.Http.Headers;
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
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthService.Jwt);
        
        string postAsJson = JsonSerializer.Serialize(dto);
        
        StringContent content = new(postAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _client.PostAsJsonAsync("/Post/create", content);
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

    public async Task<IEnumerable<PostOverviewDTO>> GetAsync(SearchPostOverviewParametersDTO searchPostOverviewParametersDto)//Bruger ikke parameter ligenu, kan være jeg vil lave søge senere
    {
        HttpResponseMessage response = await _client.GetAsync("https://localhost:7073/Post");
        string responseContent = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }

        IEnumerable<PostOverviewDTO>? postOverview = JsonSerializer.Deserialize<IEnumerable<PostOverviewDTO>>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        return postOverview!;
    }

    public async Task<PostDTO?> GetAsync(int postId)
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthService.Jwt);
        HttpResponseMessage response = await _client.GetAsync($"https://localhost:7073/Post/{postId}");
        string responseContent = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }

        var postDto = JsonSerializer.Deserialize<PostDTO>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        return postDto;
    }
}