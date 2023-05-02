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

//Quick run for docker test  -> docker run --rm -it -p 15672:15672 -p 5672:5672 --name OutdoorNotify rabbitmq:3-management
//user: guest 
//password: guest


namespace Outdoor_Notifications
{
    public static class NotificationConsumer
    {
        
        public static void startQueueConsumer()
        {
            var factory = new ConnectionFactory();// default door -> 15672
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("Notifications", exclusive: false, autoDelete: false);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, eventArgs) => {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var emailInfo = JsonConvert.DeserializeObject<NotificationModel>(message);
                Console.WriteLine($"Notifications message received: {message}");
                EmailService.sendEmail(emailInfo.UserEmail, $"Novas notificações para seu post: {emailInfo.PostName}", $"Olá {emailInfo.UserName} você tem novos reviews sobre seu post!");
            };
            channel.BasicConsume(queue: "Notifications", autoAck: true, consumer: consumer);
        }
    }
}
