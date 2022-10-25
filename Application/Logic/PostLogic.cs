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
        if (user == null) //gør tjeks bedre hvis jeg får tid
        {
            throw new Exception($"User with Username {dto.OwnerUsername} was not found.");
        }
        
        Post created = await _postDao.CreateAsync(new(user, dto.Title, dto.Topic));
        return new (created.Owner.Username, created.Title, created.Topic);
    }

    public Task<IEnumerable<Post>> GetAsync(SeachPostParaneterDTO searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}