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
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                var input = "";
                Console.WriteLine("Enter your Name, 'Quit' to quit.");
                var name = input = Console.ReadLine();
                Console.WriteLine("Enter a message. 'Quit' to quit.");
                while ((input = Console.ReadLine()) != "Quit")
                {
                    Console.WriteLine("Enter a message. 'Quit' to quit.");
                    bus.Publish(
                        new Message
                    {
                           Name = name,
                           Text = input
                    });

                }
            }
        }
    }
}
