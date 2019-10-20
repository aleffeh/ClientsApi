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
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ClientController : ControllerBase
    {
        private IClientService _clientService;

        public ClientController()
        {
            _clientService = new ClientService();
        }

        //Default value is -1 in order to diff queries.
        [HttpGet]
        public ActionResult<IEnumerator<Client>> GetById(int id = -1)
        {
            var hasQuery = id != -1;
            var result = hasQuery ? _clientService.GetClientById(id) : _clientService.GetClients();

            if (!hasQuery) return Ok(result);

            if (result.ToArray().Length == 0)
                return NotFound("Not Found On Database");
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(Client client)
        {
            if (!Validator.IsValidClient(client)) return BadRequest("Client is not valid.");
            client = _clientService.PostClient(client);
            return CreatedAtAction(nameof(GetById), new {Id = client.Id}, client);
        }

        [HttpPut("{id}")]
        public ActionResult<Client> Put(int id, [FromBody] Client client)
        {
            if (!Validator.IsValidClient(client)) return BadRequest("Client is not valid.");
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