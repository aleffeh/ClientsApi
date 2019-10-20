using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "<h1>Hello World</h1>";
        }
    }
}