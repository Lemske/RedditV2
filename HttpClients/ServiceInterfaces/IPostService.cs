using Shared.DTOs;

namespace HttpClients.ServiceInterfaces;

public interface IPostService
{
    Task<PostDTO> CreateAsync(PostCreationDTO dto);
    Task<ICollection<PostDTO>> GetAsync(string? userName, int? userId, bool? completedStatus, string? titleContains);
}