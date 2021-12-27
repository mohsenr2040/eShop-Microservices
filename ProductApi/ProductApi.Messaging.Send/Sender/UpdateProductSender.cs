using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ProductApi.Domain.Entities;
using ProductApi.Messaging.Send.Models;
using ProductApi.Messaging.Send.Options;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Messaging.Send.Sender
{
    public class UpdateProductSender : IUpdateProductSender
    {
        private readonly string _hostName;
        private readonly string _queueName;
        private readonly string _userName;
        private readonly string _password;
        private IConnection _connection;
        public UpdateProductSender(IOptions<RabbitMqConfiguration> rabbitMqOptions)
        {
            _hostName = rabbitMqOptions.Value.HostName;
            _queueName = rabbitMqOptions.Value.QueueName;
            _userName = rabbitMqOptions.Value.UserName;
            _password = rabbitMqOptions.Value.Password;
            CreateConnection(); 
        }
        public void SendProduct(UpdatedProductPriceModel updatedProductPriceModel)
        {
            if(ConnectionExists())
            {
                using (var channel=_connection.CreateModel())
                {
                    channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var json = JsonConvert.SerializeObject(updatedProductPriceModel);
                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
                }
            }
            
        }
        private bool ConnectionExists()
        {
            if(_connection!=null)
            {
                return true;
            }

            CreateConnection();

            return _connection != null;
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostName,
                    UserName = _userName,
                    Password = _password
                };
                _connection = factory.CreateConnection();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Could not create connection: {ex.Message}");
            }
        }
    }
}
