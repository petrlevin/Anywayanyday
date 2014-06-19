using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anywayanyday.Server.Contracts;

namespace Anywayanyday.Server
{
    public class Configuration : IConfiguration , IDisposable
    {

        private readonly List<Func<IController>> _controllerFactories = new List<Func<IController>>();
        private readonly RouterFactory _routerFactory = new RouterFactory();
        public virtual IFactory Factory { get; set; }

        public Configuration()
        {
            Factory = new SimpleFactory();   
        }

        public Configuration RegisterController<T>() where T : IController
        {
            _controllerFactories.Add(() => Factory.Create<T>());
            return this;
        }

        public Configuration RegisterController<T>(string route) where T : IController
        {
            _routerFactory.RegisterController<T>(route, () => Factory.Create<T>());
            return this;
        }


        public IEnumerable<IController> CreateControllers()
        {
            var controllers = _controllerFactories.Select(f => f());
            if (!_routerFactory.HasRoutes)
                return controllers;
            var result = new List<IController>() { _routerFactory.CreateRouter() };
            result.AddRange(controllers);
            return result;

        }
        public string Prefix { get; set; }
        public int QueueSize { get; set; }
        public int PoolSize { get; set; }
        public string NotFoundUrl { get; set; }

        public virtual IResponceController CreateNotFoundController()
        {
            return new NotFoundController(NotFoundUrl);
        }


        public void Dispose()
        {
            Factory.Dispose();
        }
    }
}