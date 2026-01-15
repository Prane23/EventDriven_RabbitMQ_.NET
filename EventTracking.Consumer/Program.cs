// See https://aka.ms/new-console-template for more information
using EventTracking.Consumer.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;

Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        // Register RabbitMQ connection
        services.AddSingleton<IConnection>(sp =>
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            return factory.CreateConnection();
        });

        // Register Consumer Background Service
        services.AddHostedService<RabbitMqConsumerService>();
    })
    .Build()
    .Run();

