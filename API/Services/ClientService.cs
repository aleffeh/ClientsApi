using System.Collections.Generic;
using System.Linq;
using API.Models;

namespace API.Services
{
    public class ClientService : IClientService
    {
        private static List<Client> Clients = new List<Client>();

        public IEnumerable<Client> GetClients() => Clients.ToArray().OrderBy(client => client.Id);

        public IEnumerable<Client> GetClientsByEmail(string email) => Clients
            .Where(client => client.Email.ToLower().Equals(email.ToLower())).OrderBy(client => client.Id);

        public IEnumerable<Client> GetClientsByName(string name) => Clients
            .Where(client => client.Name.ToLower().Equals(name.ToLower())).OrderBy(client => client.Id);

        public IEnumerable<Client> GetClientById(int id) => Clients.Where(client => client.Id.Equals(id));

        public Client PutClient(int id, Client client)
        {
            var item = Clients.Find(i => i.Id == id);
            if (item == null)
                return null;
            client.Id = id;
            Clients.Remove(item);
            Clients.Add(client);
            return client;
        }

        public Client PostClient(Client client)
        {
            client.Id = Clients.Count + 1;
            Clients.Add(client);
            return client;
        }

        public bool DeleteClient(int id)
        {
            var item = Clients.Find(i => i.Id == id);
            if (item == null)
                return true;
            Clients.Remove(item);
            item = Clients.Find(i => i.Id == id);
            return item == null;
        }
    }
}