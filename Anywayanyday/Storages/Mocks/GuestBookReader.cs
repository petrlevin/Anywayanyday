using System;
using System.Collections.Generic;
using Anywayanyday.Model;

namespace Anywayanyday.Storages.Mocks
{
    public class GuestBookReader: IGuestBookReader
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> Read()
        {
            return new List<Message>()
                       {
                           new Message()
                               {
                                   Content = "bla bla bla",
                                   UserId = 1
                               },
                           new Message()
                               {
                                   Content = "bla bla bla once more",
                                   UserId = 1
                               }
                       };
        }
    }
}
