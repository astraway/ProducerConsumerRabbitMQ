﻿using System;
using RabbitMQ.Client;
using System.Text;

namespace Producer
{
    class Sender
    {
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
