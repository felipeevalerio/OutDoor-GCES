using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
using OutDoor_Models.Models;
using OutDoor_Models.Models.UtilModel;
using OutDoor_Models.Responses.Notification;
using OutDoor_Models.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using IModel = RabbitMQ.Client.IModel;

namespace OutDoor_Services.UtilServices
{

    public class ConsumerService : IConsumerService
    {
        public  string HostName = "jackal-01.rmq.cloudamqp.com";
        public  string Password = "pwtxZayVOSwMb_MH4S_bRYcmAUrpT8se";
        public  string VirtualHost = "zupfssnl";
        public  string UserName = "zupfssnl";
        public  int Port = 5672;

        public IEmailService EmailService;

        public ConsumerService(IEmailService emailService)
        {
            this.EmailService = emailService;
        }

        public IModel createConnection()
        {

            return ((new ConnectionFactory()
            {
                HostName = "jackal-01.rmq.cloudamqp.com",
                Password = "pwtxZayVOSwMb_MH4S_bRYcmAUrpT8se",
                VirtualHost = "zupfssnl",
                UserName = "zupfssnl",
                Port = 5672,
            }).CreateConnection().CreateModel());


        }

        public ConfirmConsumerModel startConsumer()
        {

                var conn = createConnection();
                conn.QueueDeclare("Notifications", exclusive: false, autoDelete: false);
                var consumer = new EventingBasicConsumer(conn);
                consumer.Received += (model, eventArgs) => {
                    var body = eventArgs.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var emailInfo = JsonConvert.DeserializeObject<NotificationModel>(message);
                    EmailService.sendEmail(emailInfo.UserEmail, $"Novas notificações para seu post: {emailInfo.PostName}",
                    $"Olá {emailInfo.UserName} você tem novos reviews sobre seu post!");
                };
                conn.BasicConsume(queue: "Notifications", autoAck: true, consumer: consumer);

                return new ConfirmConsumerModel() {
                    message = "Consumidor iniciado",
                    startedAt = DateTime.Today
                };

            

        }
    }
}
