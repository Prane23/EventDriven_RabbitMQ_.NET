using EventTracking.Producer.Model;

namespace EventTracking.Producer.RabbitMQ.Interface
{
    public interface IMessageQueueService
    {
        Task SaveOrderToQueue(Order order);
    }

}
