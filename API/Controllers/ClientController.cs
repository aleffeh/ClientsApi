using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using API.Helpers;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ClientController : ControllerBase
    {
        private IClientService _clientService;

        public ClientController()
        {
            _clientService = new ClientService();
        }

        //Default value is -1 in order to diff queries.
        [HttpGet("/getHelloWorld")]
        public string Get()
        {
            return "Hello World";
        }

        [HttpPost]
        public IActionResult Post(Client client)
        {
            var output = Validator.IsValidClient(client);
            if (output != Validation.Valid) return BadRequest(Validator.GetMessage(output));
            client = _clientService.PostClient(client);
            return CreatedAtAction(nameof(Get), new {Id = client.Id}, client);
        }

        [HttpPut("{id}")]
        public ActionResult<Client> Put(int id, [FromBody] Client client)
        {
            var output = Validator.IsValidClient(client);
            if (output != Validation.Valid) return BadRequest(Validator.GetMessage(output));
            var result = _clientService.PutClient(id, client);
            if (result == null)
                return NotFound("Not Found On Database");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _clientService.DeleteClient(id);
            if (result)
                return Ok("Deleted Suscessfully");
            return NotFound("Item Not Found");
        }
    }
}