using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anywayanyday.Server.Contracts;

namespace Anywaanydays.Server.Utils
{
    public static class StringExtension
    {
        public static Verb ToVerb(this string method)
        {
            return (Verb) Enum.Parse(typeof (Verb), method.ToUpper());
        }
    }
}
