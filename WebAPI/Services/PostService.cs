using Application.LogicInterfaces;
using Shared.DTOs;
using WebAPI.Services.ServiceParent;

namespace WebAPI.Services;

public class PostService : NullCheckService, IPostService
{
    private readonly IPostLogic _postLogic;

    public PostService(IPostLogic postLogic)
    {
        _postLogic = postLogic;
    }

    public Task<PostDTO> CreatePostAsync(PostCreationDTO dto)
    {
        NullCheck(dto);
        return _postLogic.CreatePostAsync(dto);
    }

    public Task<IEnumerable<PostOverviewDTO>> GetPostOverviewAsync(SearchPostOverviewParametersDTO searchOverviewParameters)
    {
        return _postLogic.GetPostOverviewAsync(searchOverviewParameters);
    }

    public Task<PostDTO> GetPostByIdAsync(int id)
    {
        return _postLogic.GetPostAsync(id);
    }

    /*public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }*/
}