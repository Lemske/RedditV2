using Shared.DTOs;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<PostDTO> CreatePostAsync(PostCreationDTO dto);
    Task<IEnumerable<PostOverviewDTO>> GetPostOverviewAsync(SearchPostOverviewParametersDTO searchOverviewParameters);
    Task<PostDTO> GetPostAsync(int id);
    //Task UpdateAsync(TodoUpdateDto dto);
    //Task DeleteAsync(int id);
    //Task<TodoBasicDto> GetPostByIdAsync(int id);
}