using RabbitMQ.Client;
using System;
using System.Text;

namespace Producer
{
    public class Sender
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

                string message = "Hello RabbitMQ";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", "TestQueue", null, body);
                Console.WriteLine($"Sent message {message}");
            }
            Console.WriteLine($"Press any key to exit the sender app");
            Console.ReadKey();
        }

    }
}
