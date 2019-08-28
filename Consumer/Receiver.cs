using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Consumer
{
    public class Receiver
    {
        public static void Main(string[] args)
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using (var connection = connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("TestQueue", false, false, false, null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, eventArgs) =>
                {
                    var body = eventArgs.Body;
                    string message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($"Received message: {message}");
                };

                channel.BasicConsume(queue: "TestQueue", autoAck: true, consumer: consumer);
                
            }
            Console.WriteLine($"Press any key to exit the consumer app");
            Console.ReadKey();
        }
    }
}
