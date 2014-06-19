using System.Collections.Generic;

namespace Anywayanyday.Server.Contracts
{
    public interface IConfiguration
    {
        string Prefix { get; }
        int QueueSize { get; }
        int PoolSize { get;  }
        IEnumerable<IController> CreateControllers();
        IResponceController CreateNotFoundController();


    }
}
