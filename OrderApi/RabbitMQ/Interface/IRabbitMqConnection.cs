using RabbitMQ.Client;

namespace EventTracking.Producer.RabbitMQ.Interface
{
    public interface IRabbitMqConnection
    {
        IModel CreateChannel();
    }
}
