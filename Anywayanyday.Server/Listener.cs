using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Anywayanyday.Server
{
    internal class Listener : Processor,IDisposable
    {
        

       


        public Listener(HttpListener httpListener, BlockingCollection<HttpListenerContext> queue, CancellationToken ct)
        {
            if (httpListener == null) throw new ArgumentNullException("httpListener");
            if (queue == null) throw new ArgumentNullException("queue");
            
            
            

            Worker = Task.Factory.StartNew(() =>
                                      {
                                          while (true)
                                          {
                                              try
                                              {
                                                  var t = httpListener.GetContextAsync();
                                                  t.Wait(ct);
                                                  queue.Add(t.Result, ct); ;
                                              }
                                              catch (OperationCanceledException)
                                              {
                                                  queue.CompleteAdding();
                                                  return;
                                              }

                                              
                                          }

                                      }, ct);
        }


     
    }
}
