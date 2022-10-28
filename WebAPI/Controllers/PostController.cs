using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using WebAPI.Services;

namespace WebAPI.Controllers;
[ApiController]
[Authorize]
[Route("[controller]")]

public class PostController : ControllerBase 
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }
    
    [HttpPost, Route("create")]
    public async Task<ActionResult<PostDTO>> CreatePostAsync([FromBody]PostCreationDTO dto)
    {
        try
        {
            PostDTO created = await _postService.CreatePostAsync(dto);
            return Created($"/Post/create/{created.Topic}", created); //Er det her bedre end ok(obj)
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PostOverviewDTO>>> GetPostOverviewAsync([FromQuery] int? postId, [FromQuery] string? topic)
    {
        try
        {
            return Ok(await _postService.GetPostOverviewAsync(new SearchPostOverviewParametersDTO(postId, topic))); //Bruger ikke fromquery til meget ligenu
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<PostDTO>> GetPostByIdAsync([FromRoute] int id)
    {
        try
        {
            return Ok(await _postService.GetPostByIdAsync(id));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}