using OutDoor_Services.UtilServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Tests
{
    public class RabbitMQServiceTest
    {
        [Fact]
        public  void CreateMessageRabbitMQTest()
        {
            //Arrange
            var msgService = new RabbitMQService();

            //Act
            var result =  msgService.SendNotificationToQueue<string>("teste");

            //Assert
            Assert.True(result);
        }
    }
}
