using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OutDoor_Models.Models;
using OutDoor_Models.Requests.Post;
using OutDoor_Models.Responses.Notification;
using OutDoor_Models.Responses.Post;
using OutDoor_Models.Services;

namespace OutDoor_Backend.Controllers
{

    [ApiController]
    public class NotificationController : ControllerBase
    {

        public IConsumerService ConsumerService;

        public NotificationController(IConsumerService consumerService)
        {
            this.ConsumerService = consumerService;
        }

        [HttpGet]
        [Route("/api/consumer")]
        public ConfirmConsumerModel initializeConsumer()
        {
            return ConsumerService.startConsumer();
        }

    }
}
