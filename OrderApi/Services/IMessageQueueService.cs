using EventTracking.Producer.Model;

namespace EventTracking.Producer.Services
{
    public interface IMessageQueueService
    {
        Task SaveOrderToQueue(Order order);
    }

}
