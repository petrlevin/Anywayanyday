using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anywayanyday.Server.Contracts;

namespace Anywayanyday.Server
{
    internal class RouterFactory
    {
        private readonly List<KeyValuePair<string, Func<IController>>> _routes = new List<KeyValuePair<string,Func<IController>>>();
        internal void RegisterController<T>(string route, Func<IController> factory) where T : IController
        {
            var r = route.Trim();
            r = r.StartsWith("/") ? r : "/" + r;
            if (route == null) throw new ArgumentNullException("route");

            _routes.Add(new KeyValuePair<string, Func<IController>>(r, factory));

        }

        internal IController CreateRouter()
        {
            return  new Router(_routes.ToLookup(p=>p.Key,p=>p.Value()));
        }

        internal bool HasRoutes
        {
            get { return _routes.Any(); }
        }

   
    }
}
