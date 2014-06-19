using System.IO;
using System.Net;
using Anywayanyday.Server.Contracts;

namespace Anywayanyday.Controllers
{
    public class HelloWordController:IController
    {
        

        public bool ProcessRequest(HttpListenerRequest request, HttpListenerResponse response)
        {
            response.StatusCode = 200;
            response.StatusDescription = "OK";
            var writer = new StreamWriter(response.OutputStream);
            writer.Write("Hello word");
            writer.Flush();
            
            return true;
        }

        public void Dispose()
        {
            
        }
    }
}
