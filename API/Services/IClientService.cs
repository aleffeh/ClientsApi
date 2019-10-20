using System.Collections.Generic;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    public interface IClientService
    {
        IEnumerable<Client> GetClients();
        IEnumerable<Client> GetClientsByEmail(string email);
        IEnumerable<Client> GetClientsByName(string name);
        IEnumerable<Client> GetClientById(int Id);
        Client PutClient(int id, Client client);
        Client PostClient(Client client);
    }
}