using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Tests
{
    public class EmailServiceTest
    {
        [Fact]
        public async void SendEmailTest()
        {
            //Arrange 
            var emailService = new EmailService();

            //Act
            var result = emailService.sendEmail("emailTest@gmail.com", "teste", "teste");

            //Assert
            Assert.True(result);
        }
    }
}
