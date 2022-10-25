using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }
    
    [HttpPost, Route("create")]
    public async Task<ActionResult<PostDTO>> CreateAsync([FromBody]PostCreationDTO dto)
    {
        try
        {
            PostDTO created = await _postService.CreateAsync(dto);
            return Created($"/todos/{created.Topic}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}