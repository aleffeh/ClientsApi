using System.Collections.Generic;
using System.Linq;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    public class ClientService : IClientService
    {
        private static List<Client> _clients = new List<Client>();

        public IEnumerable<Client> GetClients() => _clients.ToArray();
        public IEnumerable<Client> GetClientsByEmail(string email) => _clients.Where(client => client.Email.ToLower().Equals(email.ToLower()));
        public IEnumerable<Client> GetClientsByName(string name) => _clients.Where(client => client.Name.ToLower().Equals(name.ToLower()));
        public IEnumerable<Client> GetClientById(int Id) => _clients.Where(client => client.Id.Equals(Id));

        public ActionResult PutClient(Client client)
        {
            var item = _clients.Find(i => i.Id == client.Id);
            if(item == null)
                return new NotFoundResult();
            
            _clients.Remove(item);
            _clients.Add(client);
            return new OkResult();
        }

        public Client PostClient(Client client)
        {
            client.Id = _clients.Count + 1;
            _clients.Add(client);
            return client;
        }
         
        
    }
}