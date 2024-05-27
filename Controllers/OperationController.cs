using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        [HttpGet]
        public decimal Get(decimal a, decimal b)
        {
            return a + b;
        }
        [HttpPost]
        public decimal Add(Numbers numbers, [FromHeader] string Host,
            [FromHeader(Name = "Content-Length")] string ContentLengh) //Obtener el valor de cualquier header
        {
            Console.WriteLine(Host);
            Console.WriteLine(ContentLengh);
            return numbers.A - numbers.B;
        }
        [HttpPut]
        public decimal Edit(decimal a, decimal b)
        {
            return a * b;
        }
        [HttpDelete]
        public decimal Delete(decimal a, decimal b)
        {
            return a / b;
        }
    }

    public class Numbers
    {
        public decimal A {get; set;}
        public decimal B {get; set;}
    }

}