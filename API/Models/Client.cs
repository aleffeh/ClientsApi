using System;

namespace API.Models
{
    public class Client
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Cpf { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Obs { get; set; }
    }
}