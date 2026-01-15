# 🚀EventDriven_RabbitMQ_.NET
This project demonstrates an Event-Driven Architecture using RabbitMQ and .NET 10., showcasing how a producer service and a background consumer can communicate asynchronously through message queues. 
It’s a practical, minimal example of how distributed systems exchange events without tight coupling.

The solution includes:
- Producer (ASP.NET Core Web API) → Publishes messages (orders) to RabbitMQ.
- Consumer (Console App with BackgroundService) → Listens to the queue and processes messages in real time.


## ✅ Features

Event-driven communication using RabbitMQ.
ASP.NET Core Web API for producing events.
Console application for consuming events.
Docker Compose for easy RabbitMQ setup.
Clean architecture with Dependency Injection.


## 🛠 Tech Stack
.NET 10
RabbitMQ.Client
Docker (for RabbitMQ)
ASP.NET Core Web API
Generic Host for BackgroundService

## 🚀Getting Started
1️⃣ Clone the Repository
```
git clone https://github.com/Prane23/EventDriven_RabbitMQ_.NET.git
```
2️⃣ Start RabbitMQ with Docker
Create and run RabbitMQ using Docker 
- docker run -d --hostname rmq --name rabbit-server -p 8095:15672 -p 5672:5672 rabbitmq:3-management
- Default credentials: guest / guest
- RabbitMQ Management UI : http://localhost:8095
<img width="1470" height="674" alt="image" src="https://github.com/user-attachments/assets/b7a59b1f-61e6-453c-80c9-f690fbe19833" />

3️⃣ Run Producer (Web API) and Consumer (Console App)
-  Post the order 
<img width="1601" height="954" alt="image" src="https://github.com/user-attachments/assets/db5e2c6f-1508-4086-8df8-6c90c55f1cc3" />

- You will see nicely formatted output: 
 <img width="383" height="169" alt="image" src="https://github.com/user-attachments/assets/2a1589cb-c8a8-4f5e-a478-2eba2c9d8f46" />


## 📂 Project Structure
```
EventDriven_RabbitMQ_.NET/
│
├── docker-compose.yml                # Docker setup for RabbitMQ
├── README.md                         # Documentation
│
├── EventTracking.Producer/           # ASP.NET Core Web API (Producer)
│   ├── Controllers/
│   │   └── OrdersController.cs       # API endpoint to publish orders
│   ├── Models/
│   │   └── Order.cs                  # Order model
│   │
│   ├── RabbitMQ/
│   ├── Interfaces/
│   │     ├── IMessageProducer.cs       # Interface for message producer
│   │     └── IRabbitMqConnection.cs    # Interface for RabbitMQ connection
│   ├── RabbitMqConnection.cs           # RabbitMQ connection implementation
│   └── RabbitMqProducer.cs             # Publishes messages to RabbitMQ

│   ├── Services/
│   │   └── IMessageQueueService.cs     # Interface to send orders to queue
│   │   └── MessageQueueService.cs      # Service to send orders to queue
│   ├── Program.cs                      # App startup and DI configuration
│   └── EventTracking.Producer.csproj   # Project file
│
└── EventTracking.Consumer/             # Console App (Consumer)
    ├── Models/
    │   └── Order.cs                    # Same Order model for deserialization
    ├── RabbitMQ/
    │   └── RabbitMqConsumerService.cs  # BackgroundService to consume messages
    ├── Program.cs                      # Generic Host setup for background service
    └── EventTracking.Consumer.csproj   # Project file
```
