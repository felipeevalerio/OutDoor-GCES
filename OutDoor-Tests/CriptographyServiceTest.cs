using OutDoor_Services.UtilServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Tests
{
    public class CriptographyServiceTest
    {
        [Fact]
        public void CriptographyAndDecriptographytest()
        {
            //Arrange
            var criptographyService = new CryptographyService();
            //Act
            var varCriptographyString = criptographyService.Encrypt("TestCriptography123");
            //Assert
            Assert.Equal("TestCriptography123", criptographyService.Decrypt(varCriptographyString));
        }
    }
}
