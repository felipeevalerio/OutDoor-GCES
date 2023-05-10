using Newtonsoft.Json;
using OutDoor_Models.Services;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Services.UtilServices
{
    public class RabbitMQService : IRabbitMQService
    {
        public void SendNotificationToQueue<T>(T message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "jackal-01.rmq.cloudamqp.com",
                Password = "pwtxZayVOSwMb_MH4S_bRYcmAUrpT8se",
                VirtualHost = "zupfssnl",
                UserName = "zupfssnl",
                Port = 5672,
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("Notifications", exclusive: false, autoDelete: false, arguments: null);
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: "Notifications", body: body);
        }
    }
}
