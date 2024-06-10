using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("all")]
        public List<People> GetPeople() => Repository.People;
    }

    public class Repository
    {
        public static List<People> People = new List<People>
        {
            new People()
            {
                Id = 1,
                Name = "Pedro",
                Birthdate = new DateTime(1990,12,3)
            },
            new People()
            {
                Id = 2,
                Name = "Juan",
                Birthdate = new DateTime(1990,12,3)
            },
            new People()
            {
                Id = 3,
                Name = "Ana",
                Birthdate = new DateTime(1990,12,3)
            }
        };
    }

    public class People
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public DateTime Birthdate {get; set;}
    }

}