using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anywayanyday.Server.Contracts;
using Microsoft.Practices.Unity;

namespace Anywayanyday.Server.IoC
{
    public class IoCFactory : IFactory, IDisposable
    {
        private IUnityContainer _container;
        private readonly bool _masterContainer;

        public IoCFactory(IUnityContainer container,bool masterContainer=true)
        {
            if (container == null) throw new ArgumentNullException("container");
            _container = container;
            _masterContainer = masterContainer;
        }

        public T Create<T>()
        {
            return _container.Resolve<T>();
        }


        public void Dispose()
        {
            if (_masterContainer)
                _container.Dispose();
        }
    }
}
