namespace EventTracking.Producer.RabbitMQ.Interface
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}
