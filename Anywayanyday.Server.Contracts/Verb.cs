using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anywayanyday.Server.Contracts
{
    [Flags]
    public enum Verb
    {
        OPTIONS = 1 << 0,
        GET = 1 << 1,
        HEAD = 1 << 2,
        POST = 1 << 3,
        PUT = 1 << 4,
        DELETE = 1 << 5,
        TRACE = 1 << 6,
        CONNECT = 1 << 7,
    }
}
