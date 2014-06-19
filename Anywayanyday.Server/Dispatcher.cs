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
    internal class Dispatcher : Processor
    {
        private readonly List<IController> _controllers;


        public Dispatcher(IEnumerable<IController> controllers, BlockingCollection<HttpListenerContext> queue, CancellationToken ct, IResponceController notFoundController)
        {
            if (controllers == null) throw new ArgumentNullException("controllers");
            if (queue == null) throw new ArgumentNullException("queue");
            if (notFoundController == null) throw new ArgumentNullException("notFoundController");
            _controllers = controllers.ToList();

            Worker = Task.Factory.StartNew(() =>
                                                {
                                                    try
                                                    {
                                                        foreach (var context in queue.GetConsumingEnumerable(ct))
                                                        {
                                                            if (!_controllers.Any(controller => controller.ProcessRequest(context.Request, context.Response)))
                                                                notFoundController.Process(context.Response);

                                                            context.Response.Close();



                                                        }
                                                    }
                                                    catch (OperationCanceledException)
                                                    {
                                                        return;
                                                    }


                                                }, ct);
        }


        public override void Dispose()
        {
            base.Dispose();
            foreach (var controller in _controllers)
            {
                controller.Dispose();
            }
        }
    }



}
