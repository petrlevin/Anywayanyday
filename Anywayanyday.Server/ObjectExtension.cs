using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anywayanyday.Server
{
    public static class ObjectExtension
    {
        public static void Dispose(this object @object)
        {
            var disposable = @object as IDisposable;
            if (disposable != null)
                disposable.Dispose();
        }
    }
}
