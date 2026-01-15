using EventTracking.Producer.Model;
using EventTracking.Producer.RabbitMQ.Interface;

namespace EventTracking.Producer.Services
{
    public class MessageQueueService : IMessageQueueService
    {
        private readonly IMessageProducer _messageProducer;

        public MessageQueueService(IMessageProducer messageProducer)
        {
            _messageProducer = messageProducer;
        }

        public async Task SaveOrderToQueue(Order order)
        {
            if (order != null)
                _messageProducer.SendMessage(order);

            await Task.CompletedTask;
        }
    }

}
