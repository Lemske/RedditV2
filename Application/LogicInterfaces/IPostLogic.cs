using Domain.Models;
using Shared.DTOs;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<PostDTO> CreateAsync(PostCreationDTO dto);
    Task<IEnumerable<Post>> GetAsync(SeachPostParaneterDTO searchParameters);
    //Task UpdateAsync(TodoUpdateDto dto);
    Task DeleteAsync(int id);
    //Task<TodoBasicDto> GetByIdAsync(int id);
}