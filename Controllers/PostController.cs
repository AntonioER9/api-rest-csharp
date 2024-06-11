using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using Backend.Services;
using Backend.DTOs;


namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostService _titlesService;
        public PostController(IPostService titleService)
        {
            _titlesService = titleService;
        }
        [HttpGet]
        public async Task<IEnumerable<PostDto>> Get() => 
            await _titlesService.Get();
    }
}