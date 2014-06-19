using System;
using System.Net;
using Anywayanyday.Server.Contracts;

namespace Anywayanyday.Controllers
{
    public class GuestBookController<TReader, TWriter> : GuestBookController,IController
        where TReader:IGuestBookReader,new() 
        where TWriter: IGuestBookWriter,new()
    {
        public GuestBookController() : base(new TReader(), new TWriter())
        {
        }
    }
}
