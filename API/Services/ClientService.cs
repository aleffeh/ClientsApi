using System.Collections.Generic;
using System.Linq;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    public class ClientService : IClientService
    {
        private static List<Client> _clients = new List<Client>();

        public IEnumerable<Client> GetClients() => _clients.ToArray().OrderBy(client => client.Id);

        public IEnumerable<Client> GetClientsByEmail(string email) => _clients
            .Where(client => client.Email.ToLower().Equals(email.ToLower())).OrderBy(client => client.Id);

        public IEnumerable<Client> GetClientsByName(string name) => _clients
            .Where(client => client.Name.ToLower().Equals(name.ToLower())).OrderBy(client => client.Id);

        public IEnumerable<Client> GetClientById(int Id) => _clients.Where(client => client.Id.Equals(Id));

        public Client PutClient(int id, Client client)
        {
            var item = _clients.Find(i => i.Id == id);
            if (item == null)
                return null;
            client.Id = id;
            _clients.Remove(item);
            _clients.Add(client);
            return client;
        }

        public Client PostClient(Client client)
        {
            client.Id = _clients.Count + 1;
            _clients.Add(client);
            return client;
        }

        public bool DeleteClient(int id)
        {
            var item = _clients.Find(i => i.Id == id);
            if (item == null)
                return true;
            _clients.Remove(item);
            item = _clients.Find(i => i.Id == id);
            return item == null;
        }
    }
}