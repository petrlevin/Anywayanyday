using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Anywayanyday.Server.Contracts;

namespace Anywayanyday.Server
{
    public class NotFoundController:IResponceController
    {
        private readonly string _redirectUrl;

        public NotFoundController(string redirectUrl)
        {
            if (redirectUrl == null) throw new ArgumentNullException("redirectUrl");
            this._redirectUrl = redirectUrl;
        }

        public void Process(HttpListenerResponse response)
        {
            response.Redirect(_redirectUrl);
        }
    }
}
