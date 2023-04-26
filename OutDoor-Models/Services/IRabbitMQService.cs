using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Models.Services
{
    public interface IRabbitMQService
    {
        public void SendNotifiationToQueue<T>(T message);
    }

}
