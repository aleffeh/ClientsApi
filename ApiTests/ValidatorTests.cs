using API.Helpers;
using API.Models;
using NUnit.Framework;

namespace ApiTests
{
    public class ValidatorTests
    {
        readonly Client client = new Client
        {
            Name = "Felipe Oliveira",
            Adress = "Armando Martiminiano",
            Birthday = "06/01/2000",
            Cpf = "673.245.860-40",
            Email = "felipexk1@live.com",
            PhoneNumber = "(17) 99192-8474",
            Obs = "Teste som um dois tres"
        };

        [Test]
        [TestCase("125.192.550-21")]
        [TestCase("12519255021")]
        [TestCase("27308983870")]
        [TestCase("22236268823")]
        public void CPF_IsValid(string cpf)
        {
            Assert.AreEqual(true, Validator.IsValidCpf(cpf));

        }

        [Test]
        [TestCase("125.122.560-25")]
        [TestCase("12569252029")]
        [TestCase("1256925202")]
        public void CPF_IsNotValid(string cpf)
        {
            
            Assert.AreNotEqual(true, Validator.IsValidCpf(cpf));
        }

        [Test]
        public void ValidaCpf() => Assert.AreEqual(true, Validator.IsValidCpf(client.Cpf));

        [Test]
        public void ValidaObs() => Assert.AreEqual(true, Validator.IsValidObs(client.Obs));

        [Test]
        public void ValidaPhoneNumber() => Assert.AreEqual(true, Validator.IsValidCellPhoneNumber(client.PhoneNumber));

        [Test]
        public void ValidaBirthday() => Assert.AreEqual(true, Validator.IsValidDate(client.Birthday));

        [Test]
        public void ValidaNull() => Assert.AreEqual(true, Validator.IsNotNull(client));

        [Test]
        public void ValidaClient() => Assert.AreEqual(Validation.Valid, Validator.IsValidClient(client));

        [Test]
        
        [TestCase("(17) 99192-8474")]
        public void ValidaPhoneNumber_Correto(string value) =>
            Assert.AreEqual(true, Validator.IsValidCellPhoneNumber(value));

        [Test]
        [TestCase("17991928474")]
        [TestCase("(17)99192-8474")]
        [TestCase("(17) 3192-8474")]
        public void ValidaPhoneNumber_Incorreto(string value) =>
            Assert.AreNotEqual(true, Validator.IsValidCellPhoneNumber(value));

    }
}
