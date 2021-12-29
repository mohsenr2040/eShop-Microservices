
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OrderApi.Messaging.Receive.Options;
using OrderApi.Service.Models;
using OrderApi.Service.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderApi.Messaging.Receive.Receiver
{
    public class ProductPriceUpdateReceiver:BackgroundService
    {
        private IModel _channel;
        private IConnection _connection;
        private readonly IProductPriceUpdateService _productPriceUpdateService;
        private readonly string _hostname;
        private readonly string _queuename;
        private readonly string _username;
        private readonly string _password;
        public ProductPriceUpdateReceiver(IProductPriceUpdateService productPriceUpdateService,IOptions<RabbitMqConfiguration> rabbimqoptions)
        {
            _productPriceUpdateService = productPriceUpdateService;
            _hostname = rabbimqoptions.Value.HostName;
            _queuename = rabbimqoptions.Value.QueueName;
            _username = rabbimqoptions.Value.UserName;
            _password = rabbimqoptions.Value.Password;

            InitializerabbitMqListener();
        }
        private void InitializerabbitMqListener()
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password
            };
            _connection = factory.CreateConnection();
            _connection.ConnectionShutdown+= RabbitMQ_ConnectionShutdown;
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: _queuename, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
             {
                 var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                 var updateProductPriceModel = JsonConvert.DeserializeObject<UpdateProductPriceModel>(content);
                 HandleMessage(updateProductPriceModel);
                 _channel.BasicAck(ea.DeliveryTag, false);
             };
            consumer.Shutdown += OnConsumerShutdown;
            consumer.Registered += OnConsumerRegistered;
            consumer.Unregistered += OnConsumerUnregistered;
            consumer.ConsumerCancelled += OnConsumerCancelled;

            _channel.BasicConsume(_queuename, false, consumer);

            return Task.CompletedTask;
        }
        private void HandleMessage(UpdateProductPriceModel updateProductPriceModel)
        {
            _productPriceUpdateService.UpdateProductInOrderDetails(updateProductPriceModel);
        }

        private void OnConsumerCancelled(object sender, ConsumerEventArgs e)
        {
        }

        private void OnConsumerUnregistered(object sender, ConsumerEventArgs e)
        {
        }

        private void OnConsumerRegistered(object sender, ConsumerEventArgs e)
        {
        }

        private void OnConsumerShutdown(object sender, ShutdownEventArgs e)
        {
        }

        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}
