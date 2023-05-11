using Microsoft.EntityFrameworkCore.Metadata;
using OutDoor_Models.Responses.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IModel = RabbitMQ.Client.IModel;

namespace OutDoor_Models.Services
{
    public interface IConsumerService
    {
        public IModel createConnection();

        public ConfirmConsumerModel startConsumer();
    }
}
