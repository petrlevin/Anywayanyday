using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anywayanyday.Server.Contracts
{
    public interface IFactory
    {
        T Create<T>();
    }
}
