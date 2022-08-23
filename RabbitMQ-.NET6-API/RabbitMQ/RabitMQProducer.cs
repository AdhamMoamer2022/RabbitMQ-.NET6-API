using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMQ_.NET6_API.RabbitMQ
{
    public class RabitMQProducer : IRabitMQProducer
    {
        public void SendProductMessage<T>(T message)
        {
            // specify the Rabbit mq server// using the docker image
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            //create connection
            var connection = factory.CreateConnection();

            //create channel with session and model
            using

            var channel = connection.CreateModel();

            channel.QueueDeclare("product",exclusive:false);
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange:"",routingKey:"product",body:body);

        }
    }
}
