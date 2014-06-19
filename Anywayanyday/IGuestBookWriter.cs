using System;
using Anywayanyday.Model;

namespace Anywayanyday
{
    public interface IGuestBookWriter : IDisposable
    {
        void Write(Message data);


    }
}
