﻿using Aspire.RabbitMQSample.ServiceApp.Services;

using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddRabbitMQClient("RabbitMQConnection");

builder.Services.AddHostedService<RabbitMqDirectFirstBackgroundService>();
builder.Services.AddHostedService<RabbitMqDirectSecondBackgroundService>();
builder.Services.AddHostedService<RabbitMqFanoutFirstBackgroundService>();
builder.Services.AddHostedService<RabbitMqFanoutSecondBackgroundService>();
builder.Services.AddHostedService<RabbitMqTopicFirstBackgroundService>();
builder.Services.AddHostedService<RabbitMqTopicSecondBackgroundService>();
builder.Services.AddHostedService<RabbitMqTopicOtherBackgroundService>();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();