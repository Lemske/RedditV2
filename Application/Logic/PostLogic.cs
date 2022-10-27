using Application.LogicInterfaces;
using Domain.Models;
using FileData.DAOInterfaces;
using Shared.DTOs;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDAO _postDao;
    private readonly IAuthDAO _authDao;

    public PostLogic(IPostDAO postDao, IAuthDAO authDao)
    {
        _postDao = postDao;
        _authDao = authDao;
    }

    public async Task<PostDTO> CreateAsync(PostCreationDTO dto)
    {
        User? user = await _authDao.GetByUsernameAsync(dto.OwnerUsername);
        if (user == null)
        {
            throw new Exception($"User with Username {dto.OwnerUsername} was not found.");
        }
        
        Post created = await _postDao.CreateAsync(new(user, dto.Title, dto.Topic));
        return new (created.Owner.Username, created.Title, created.Topic);
    }

    public async Task<IEnumerable<PostOverviewDTO>> GetAsync(SearchPostOverviewParametersDTO searchOverviewParameters)
    {
        var posts = await _postDao.GetAsync(searchOverviewParameters);
        return posts.Select(post => new PostOverviewDTO(post.Id, post.Title)).ToList();
    }

    public async Task<PostDTO> GetAsync(int id)
    {
        Post? post = await _postDao.GetByIdAsync(id);
        if (post == null)
            throw new Exception($"Id {id} does not exist!");
        return new PostDTO(post.Owner.Username, post.Title, post.Topic);
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}