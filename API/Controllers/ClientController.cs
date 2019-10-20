using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ClientController : ControllerBase
    {
        private IClientService ClientService;

        public ClientController()
        {
            ClientService = new ClientService();
        }
//
//        [HttpGet]
//        public IEnumerable<Client> Get()
//        {
//            return ClientService.GetClients();
//        }

        [HttpGet]
        public ActionResult<IEnumerator<Client>> GetById(int id = -1)
        {
            var hasQuery = id != -1;
            var result = hasQuery ? ClientService.GetClientById(id) : ClientService.GetClients();
            
            if (!hasQuery) return Ok(result);
            
            if (result.ToArray().Length == 0)
                return NotFound("Not Found On Database");
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(Client client)
        {
            client = ClientService.PostClient(client);
            return CreatedAtAction(nameof(GetById), new {Id = client.Id}, client);
        }

        [HttpPut("{id}")]
        public ActionResult<Client> Put(int id,[FromBody]Client client)
        {
            var result =  ClientService.PutClient(id,client);
            if (result == null)
                return NotFound("Not Found On Database");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = ClientService.DeleteClient(id);
            if (result)
                return Ok("Deleted Suscessfully");
            return NotFound("Item Not Found");
        }
    }
}