using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet("all")]
        public List<People> GetPeople() => Repository.People;
        [HttpGet("{id}")]
        public ActionResult<People> Get(int id){
            var people = Repository.People.FirstOrDefault(p => p.Id == id);
            if (people == null)
            {
                return NotFound();
            }
            return Ok(people);
        }
        [HttpGet("search/{search}")]
        public List<People> Get(string search) => 
            Repository.People.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList();
        [HttpPost]
        public IActionResult Add(People people)
        {
            if (!_peopleService.Validate(people))
            {
                return BadRequest();
            }
            
            Repository.People.Add(people);
            
            return NoContent();
        }
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