using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anywayanyday.Server
{
    abstract internal class Processor:IDisposable
    {
        protected  Task Worker;

 
        public virtual void Dispose()
        {
            Worker.Wait();
        }
    }
}
