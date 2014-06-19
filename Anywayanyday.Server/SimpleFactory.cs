using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anywayanyday.Server.Contracts;

namespace Anywayanyday.Server
{
    public class SimpleFactory:IFactory
    {
        public T Create<T>()
        {
            return Activator.CreateInstance<T>();
        }
    }
}
