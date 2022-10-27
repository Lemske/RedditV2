using Domain.Models;
using Shared.DTOs;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<PostDTO> CreateAsync(PostCreationDTO dto);
    Task<IEnumerable<PostOverviewDTO>> GetAsync(SearchPostOverviewParametersDTO searchOverviewParameters);
    Task<PostDTO> GetAsync(int id);
    //Task UpdateAsync(TodoUpdateDto dto);
    Task DeleteAsync(int id);
    //Task<TodoBasicDto> GetByIdAsync(int id);
}