
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace FormulaAirline.API.Services
{
    public class MessageProducer : IMessageProducer
    {
        public void SendingMessages<T>(T message)
        {
            // Obviously, you should not be hard coding these values in a real-world application.
            var factory = new ConnectionFactory() {
                HostName = "localhost",
                UserName = "user",
                Password = "mypassword",
                VirtualHost = "/"
            };

            var conn = factory.CreateConnection();

            using var channel = conn.CreateModel();

            channel.QueueDeclare("bookings", durable: true, exclusive: true);

            var jsonString = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonString);

            channel.BasicPublish("", "bookings", body: body);
        }
    }
}