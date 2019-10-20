using System.Collections;
using System.Collections.Generic;
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
        
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return ClientService.GetClients();
        }

        [HttpPost]
        public Client Post(Client client)
        {
          return ClientService.PostClient(client);
        }
    }
}