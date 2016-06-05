using EasyNetQ;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher
{
    class Program
    {
        public static string name { get; set; }
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                var input = "";
                Console.WriteLine("Enter your Name, 'Quit' to quit.");
                name = input = Console.ReadLine();      
                Console.WriteLine("Enter a message. 'Quit' to quit.");
                Random rnd = new Random();
                int unique_id = rnd.Next(10000);
                bus.Subscribe<Message>(unique_id.ToString(), HandleMessage);
                while ((input = Console.ReadLine()) != "Quit")
                {
                    bus.Publish(
                        new Message
                    {
                           Name = name,
                           Text = input
                    });
                }
            }

        }
        static void HandleMessage(Message textMessage)
        {
            if (textMessage.Name == name)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("{0}: {1}", textMessage.Name, textMessage.Text);
            Console.ResetColor();
        }
    }
}
