using Microsoft.AspNetCore.Mvc.ApiExplorer;
using EventTracking.Producer.RabbitMQ;
using EventTracking.Producer.RabbitMQ.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRabbitMqConnection>(sp =>
{
    return new RabbitMqConnection(); 
});

builder.Services.AddScoped<IMessageProducer, RabbitMqProducer>();
builder.Services.AddScoped<IMessageQueueService, MessageQueueService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
