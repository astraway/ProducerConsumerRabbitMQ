using System;
using RabbitMQ.Client;
using System.Text;

namespace Producer
{
    class Sender
    {
        // creates an image with port 8080 connected to the ui and port 5672 connected to rabbitmq
        //docker run -d --hostname my-rabbit --name some-rabbit -p 8080:15672 -p 5672:5672 rabbitmq:3-management

        //gui located at
        //http://localhost:8080

        //user/password of guest / guest


        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", Port = 5672 };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {

                channel.QueueDeclare("BasicTest", false, false, false, null);

                string message = "Getting started with RabbitMQ";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", "BasicTest", null, body);
                Console.WriteLine("Sent Message {0} ... ", message);

            }
            Console.WriteLine("Press enter to close sender");
            Console.ReadLine();

        }
    }
}
