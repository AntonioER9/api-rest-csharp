using Backend.Controllers;
using Backend.DTOs;

namespace Backend.Services
{
  public interface IPostService
  {
    public Task<IEnumerable<PostDto>> Get();
  }
}