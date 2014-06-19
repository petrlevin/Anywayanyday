using System.Net;

namespace Anywayanyday.Server.Contracts
{
    public interface IResponceController
    {
        void Process(HttpListenerResponse response);
   
    }
}
