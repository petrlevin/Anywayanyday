using System;
using System.Collections.Generic;
using Anywayanyday.Model;

namespace Anywayanyday
{
    public  interface IGuestBookReader : IDisposable
    {
         IEnumerable<Message> Read();
    }
}
