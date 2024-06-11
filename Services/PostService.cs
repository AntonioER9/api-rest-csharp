using System.Text.Json;
using Backend.DTOs;

namespace Backend.Services
{
  public class PostService : IPostService
  {
    private HttpClient _httpClient;

    public PostService()
    {
      _httpClient = new HttpClient();
    }

    public async Task<IEnumerable<PostDto>> Get()
    {
      string url = "https://jsonplaceholder.typicode.com/posts";
      var result = await _httpClient.GetAsync(url);
      var body = await result.Content.ReadAsStringAsync();

      var options = new JsonSerializerOptions //Permitir serialización con Mayus o minus
      {
        PropertyNameCaseInsensitive = true
      };

      var post = JsonSerializer.Deserialize<IEnumerable<PostDto>>(body, options);
      return post;
    }

  }
}