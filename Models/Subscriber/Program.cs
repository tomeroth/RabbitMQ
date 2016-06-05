using EasyNetQ;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<Message>("test", HandleMessage);

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        static void HandleMessage(Message textMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}: {1}",textMessage.Name, textMessage.Text);
            Console.ResetColor();
        }
    }
}
