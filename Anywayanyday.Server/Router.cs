using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Anywayanyday.Server.Contracts;

namespace Anywayanyday.Server
{
    public class Router:IController
    {
        
        private readonly ILookup<string, IController> _map;
        private Regex _pathRegex;// = new Regex(@"^([\\\w \.-]*)",RegexOptions.Compiled);

        private bool BuildMap()
        {
            if (_pathRegex != null)
                return true;
            if (_map.Count == 0)
                return false;
            
             var pattern = "^" + String.Join("|", _map.Select(g=>g.Key).Select(r=>String.Format("({0})", r)))+@"($|\?)";
            _pathRegex = new Regex(pattern,RegexOptions.Compiled);
            return true;
        }

        internal Router(ILookup<string, IController> map)
        {
            if (map == null) throw new ArgumentNullException("map");
            _map = map;
        }

        public void Dispose()
        {
           
        }

        public bool ProcessRequest(HttpListenerRequest request, HttpListenerResponse response)
        {
            if (!BuildMap())
                return false;
            if (_pathRegex == null)
                return false;
            var match = _pathRegex.Match(request.RawUrl);
            if (!match.Success)
                return false;

            return (_map[match.Groups[1].Value].Any(controller => controller.ProcessRequest(request, response)));


        }

     
    }
}
