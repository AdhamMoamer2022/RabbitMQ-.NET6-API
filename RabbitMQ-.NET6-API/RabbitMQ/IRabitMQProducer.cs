namespace RabbitMQ_.NET6_API.RabbitMQ
{
    public interface IRabitMQProducer
    {
        public void SendProductMessage<T>(T message);
    }
}
