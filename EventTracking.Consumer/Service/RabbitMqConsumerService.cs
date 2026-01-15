using EventTracking.Consumer.Model;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;


namespace EventTracking.Consumer.Service
{
    public class RabbitMqConsumerService : BackgroundService
    {
        private readonly IConnection _connection;
        private IModel _channel;

        public RabbitMqConsumerService(IConnection connection)
        {
            _connection = connection;
            _channel = _connection.CreateModel();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _channel.QueueDeclare("orders", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var order = JsonSerializer.Deserialize<Order>(message);

                Console.WriteLine("***************************************");
                Console.WriteLine("         [Consumer] Received Order     ");
                Console.WriteLine("***************************************");
                Console.WriteLine($"Order Id   : {order?.OrderId}");
                Console.WriteLine($"Product    : {order?.Product}");
                Console.WriteLine($"Quantity   : {order?.Quantity}");
                Console.WriteLine($"Price      : {order?.Price}");
                Console.WriteLine("***************************************\n");

            };

            _channel.BasicConsume(queue: "orders", autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
            base.Dispose();
        }
    }
}



