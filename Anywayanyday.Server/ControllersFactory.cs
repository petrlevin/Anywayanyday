using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anywayanyday.Server.Contracts;

namespace Anywayanyday.Server
{
    public class ControllersFactory
    {
        protected readonly List<Func<IController>> _controllerFactories = new List<Func<IController>>();
        public void RegisterController<T>() where T : IController, new()
        {
            _controllerFactories.Add(() => new T());
        }

    }
}
