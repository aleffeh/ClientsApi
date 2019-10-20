using API.Helpers;
using NUnit.Framework;

namespace ApiTests
{
    public class ValidatorTests
    {
      
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
    }
}