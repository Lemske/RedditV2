using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using WebAPI.Services;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
[Authorize]
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
            return Created($"/Post/create/{created.Topic}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PostOverviewDTO>>> GetAsync([FromQuery] int? postID, [FromQuery] string? topic)
    {
        try
        {
            return Ok(await _postService.GetAsync(new SearchPostOverviewParametersDTO(postID, topic))); //Bruger ikke fromquery til meget ligenu
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<PostDTO>> GetAsync([FromRoute] int id)
    {
        try
        {
            return Ok(await _postService.GetAsync(id));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
}