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
            Cpf = "479.280.648.80",
            Email = "felipexk1@live.com",
            PhoneNumber = "(17) 99192-8474",
            Obs = "Teste som um dois trws"
        };
      
        [Test]
        public void ValidaCpfComPontuacao()
        {
            const string validCpf = "125.192.550-21";
            const string invalidCpf = "125.122.560-25";
            
            Assert.AreEqual(true,Validator.IsValidCpf(validCpf));
            Assert.AreNotEqual(true,Validator.IsValidCpf(invalidCpf));
        }
        
        [Test]
        public void ValidaCpfSemPontuacao()
        {
            const string validCpf = "12519255021";
            const string invalidCpf = "12569252029";
            
            Assert.AreEqual(true,Validator.IsValidCpf(validCpf));
            Assert.AreNotEqual(true,Validator.IsValidCpf(invalidCpf));
        }

        [Test]
        public void ValidaCpf() => Assert.AreEqual(true,Validator.IsValidCpf(client.Cpf));

        [Test]
        public void ValidaObs() => Assert.AreEqual(true,Validator.IsValidObs(client.Obs));

        [Test]
        public void ValidaPhoneNumber() => Assert.AreEqual(true, Validator.IsValidCellPhoneNumber(client.PhoneNumber));
        [Test]
        public void ValidaBirthday() => Assert.AreEqual(true,Validator.IsValidDate(client.Birthday));
        [Test]
        public void ValidaNull() => Assert.AreEqual(true,Validator.IsNotNull(client));


        
        [Test]
        public void ValidaPhoneNumberCorreto() => Assert.AreEqual(true,Validator.IsValidCellPhoneNumber("(17) 99192-8474"));  
        [Test]
        public void ValidaPhoneNumberSemEspaco() => Assert.AreNotEqual(true,Validator.IsValidCellPhoneNumber("(17)99192-8474"));
        [Test]
        public void ValidaPhoneNumberSemMarcacao() => Assert.AreNotEqual(true,Validator.IsValidCellPhoneNumber("17991928474"));
        [Test]
        public void ValidaPhoneNumberFixo() => Assert.AreEqual(true,Validator.IsValidCellPhoneNumber("(17) 3192-8474"));  
    }
}