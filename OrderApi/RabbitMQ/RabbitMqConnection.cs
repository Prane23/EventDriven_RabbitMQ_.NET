using EventTracking.Producer.RabbitMQ.Interface;
using RabbitMQ.Client;

namespace EventTracking.Producer.RabbitMQ
{
    public class RabbitMqConnection : IRabbitMqConnection, IDisposable
    {


        private readonly IConnection _connection;

        public RabbitMqConnection()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
        }

        public IModel CreateChannel() => _connection.CreateModel();

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
