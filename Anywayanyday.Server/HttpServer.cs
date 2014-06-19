using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Anywayanyday.Server.Contracts;

namespace Anywayanyday.Server
{
    public class HttpServer : IDisposable
    {
        private readonly IConfiguration _configuration;

        private readonly HttpListener _httpListener;
        private Listener _listener;
        private List<Dispatcher> _dispatchers;

        private BlockingCollection<HttpListenerContext> _queue;
        private CancellationTokenSource _cancelationTokenSource;

        public HttpServer(IConfiguration configuration, bool autoStart = true)
        {
            _configuration = configuration;

            _httpListener = new HttpListener();
            _httpListener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
            _httpListener.Prefixes.Add(configuration.Prefix);
            if (autoStart)
                DoStart();
        }

        public void Start()
        {
            if (_httpListener.IsListening)
                throw new InvalidOperationException(String.Format("Server is already started. Server's prefix:{0}.", _configuration.Prefix));
            DoStart();
        }

        public void Stop()
        {
            if (!_httpListener.IsListening)
                throw new InvalidOperationException(String.Format("Server is not started yet. Server's prefix:{0}.", _configuration.Prefix));
            DoStop();
        }


        private void DoStart()
        {

            _queue = new BlockingCollection<HttpListenerContext>(_configuration.QueueSize);
            _cancelationTokenSource = new CancellationTokenSource();
            
            _httpListener.Start();
            var ct = _cancelationTokenSource.Token;
            
            _dispatchers = new List<Dispatcher>();
            for (int i = 0; i < _configuration.PoolSize; i++)
            {
                _dispatchers.Add(new Dispatcher(_configuration.CreateControllers(), _queue, ct, _configuration.CreateNotFoundController()));
            }
            _listener = new Listener(_httpListener, _queue, ct);

           

        }


  


        private void DoStop()
        {
           
            _cancelationTokenSource.Cancel();
            _listener.Dispose();
            foreach (var dispatcher in _dispatchers)
            {
                dispatcher.Dispose();
            }
            
            _httpListener.Stop();
        }


        public void Dispose()
        {
            if (_httpListener.IsListening)
                DoStop();
            _configuration.Dispose();
        }
    }

}
