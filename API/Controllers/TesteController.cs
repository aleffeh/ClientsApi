using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api")]
    [Produces(MediaTypeNames.Application.Json)]
    public class TesteController : Controller
    {
        [HttpGet("/getTeste")]
        public string Get()
        {
            return "Teste";
        }
    }
}