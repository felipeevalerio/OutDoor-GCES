using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using OutDoor_Models.Models.UtilModel;
using OutDoor_Models.Services;
using OutDoor_Services.UtilServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Tests
{
    public class ConsumerServiceTest
    {
        [Fact]
        public  void StartConsumerTest()
        {
            //Arrange
            var emailService = new EmailService();
            var consumerService = new ConsumerService(emailService);

            //Act
            var result = consumerService.startConsumer();

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Consumidor iniciado", result.message);
            Assert.Equal(DateTime.Today, result.startedAt);
            Assert.Equal<string>("jackal-01.rmq.cloudamqp.com", consumerService.HostName);
            Assert.Equal<string>("pwtxZayVOSwMb_MH4S_bRYcmAUrpT8se", consumerService.Password);
            Assert.Equal<string>("zupfssnl", consumerService.VirtualHost);
            Assert.Equal<string>("zupfssnl", consumerService.UserName);
            Assert.Equal<int>(5672, consumerService.Port);

        }

        [Fact]
        public void NotificationModelTest()
        {
            var notifyModel = new NotificationModel() { 
                PostName = "postName",
                UserEmail = "userEmail",
                UserName = "userName"
            };

            Assert.Equal("postName", notifyModel.PostName);
            Assert.Equal("userEmail", notifyModel.UserEmail);
            Assert.Equal("userName", notifyModel.UserName);


        }
    }
}
