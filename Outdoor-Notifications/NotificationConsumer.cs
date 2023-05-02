using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace Outdoor_Notifications
{
    public static class NotificationConsumer
    {
        
        public static void starQueueConsumer()
        {
            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("Notifications", exclusive: false, autoDelete: false);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, eventArgs) => {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var emailInfo = JsonConvert.DeserializeObject<NotificationModel>(message);
                //getObject
                Console.WriteLine($"Notifications message received: {message}");
                EmailService.sendEmail(emailInfo.UserEmail, $"Novas notificações para seu post: {emailInfo.PostName}", $"Olá {emailInfo.UserName} você tem novos reviews sobre seu post!");
            };
            channel.BasicConsume(queue: "Notifications", autoAck: true, consumer: consumer);
        }
    }
}
