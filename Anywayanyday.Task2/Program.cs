using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Anywayanyday.Controllers;
using Anywayanyday.Server;
using Anywayanyday.Server.IoC;
using Microsoft.Practices.Unity;

namespace Anywayanyday.Task1
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Starting server");
            using (new HttpServer(
                    new Configuration()
                        .PoolSize(5)
                        .QueueSize(100)
                        .Prefix("http://localhost:7896/")
                        .NotFoundUrl("http://simoncropp.com/simpleclientandserverwithhttplistener")
                        .Factory(new IoCFactory(
                                new UnityContainer()
                                    .RegisterType<IGuestBookReader, Storages.Mocks.GuestBookReader>()
                                    .RegisterType<IGuestBookWriter, Storages.Xml.GuestBookWriter>()

                            ))
                        .RegisterController<GuestBookController>("guestbook")
                        .RegisterController<HelloWordController>()))
            {
                Console.WriteLine("Server have been started");
                Console.ReadLine();
                Console.WriteLine("Stoping server");
            }
            Console.WriteLine("Server have been stopped");
            Thread.Sleep(1000);
        }
    }
}
