
using EventTracking.Producer.RabbitMQ.Interface;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;


namespace EventTracking.Producer.RabbitMQ
{
    public class RabbitMqProducer : IMessageProducer
    {


        private readonly IRabbitMqConnection _connection;

        public RabbitMqProducer(IRabbitMqConnection connection)
        {
            _connection = connection;
        }

        public void SendMessage<T>(T message)
        {
            using var channel = _connection.CreateChannel();
            channel.QueueDeclare("orders", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "orders", basicProperties: null, body: body);
        }


    }

}