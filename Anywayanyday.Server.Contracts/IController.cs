using System;
using System.Net;

namespace Anywayanyday.Server.Contracts
{
    public interface IController:IDisposable
    {
        bool ProcessRequest(HttpListenerRequest request, HttpListenerResponse response);
    
    }
}
