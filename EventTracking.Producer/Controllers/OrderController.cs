using Microsoft.AspNetCore.Mvc;
using EventTracking.Producer.Model;
using EventTracking.Producer.Services;

namespace EventTracking.Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMessageQueueService _orderQueueService;

        public OrderController(IMessageQueueService orderQueueService)
        {
            _orderQueueService = orderQueueService;
        }


        [HttpPost]
        public ActionResult Post([FromBody] Order order)
        {

            if (order == null)
                return BadRequest("Order cannot be null");

            //Save order to db here

            // Call your method to save the order to RabbitMQ
            _orderQueueService.SaveOrderToQueue(order);

            return CreatedAtAction(
            nameof(Get),                     // The action name to generate the URI
             new { id = order.OrderId },      // Route values for that action
             order                            // The content to return in the response body
     );
        }

        [HttpGet]
        public ActionResult Get(int id)
        {
            return Ok();
        }
    }
}
