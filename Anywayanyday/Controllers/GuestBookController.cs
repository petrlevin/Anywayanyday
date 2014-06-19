using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Serialization;
using Anywaanydays.Server.Utils;
using Anywayanyday.Server.Contracts;
using Newtonsoft.Json;

namespace Anywayanyday.Controllers
{
    public class GuestBookController:IController
    {

        private readonly IGuestBookReader _reader;
        private readonly IGuestBookWriter _writer;

        public GuestBookController(IGuestBookReader reader, IGuestBookWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }


        public void Dispose()
        {
            _reader.Dispose();
            _writer.Dispose();

        }

        public bool ProcessRequest(HttpListenerRequest request, HttpListenerResponse response)
        {
            var verb = request.HttpMethod.ToVerb();
            if (verb == Verb.GET)
                return ReadGuestbook(request.AcceptTypes, response);
            if (verb == Verb.POST)
                return WriteGuestbook(request.InputStream, response);
            return false;

        }

        private bool WriteGuestbook(Stream inputStream, HttpListenerResponse response)
        {

            

        }

        private bool ReadGuestbook(string[] acceptTypes, HttpListenerResponse response)
        {
            var messages = _reader.Read();
            if (acceptTypes.Any(a=>a.StartsWith("application/json", StringComparison.OrdinalIgnoreCase)||a.Equals("*/*")))
            {
                WriteToOutput(response,
                              writer =>
                                    new JsonSerializer().Serialize(writer, messages));
                response.ContentType = "application/json";
              
                return true;
            }
            if (acceptTypes.Any(a => a.StartsWith("application/xml", StringComparison.OrdinalIgnoreCase)))
            {
                WriteToOutput(response,
                              writer =>
                                    new XmlSerializer(messages.GetType()).Serialize(writer,messages));
                response.ContentType = "application/xml";
                
                return true;
            }
           return  false;
           
        }

        private void WriteToOutput(HttpListenerResponse response,Action<StreamWriter> action)
        {
            var writer = new StreamWriter(response.OutputStream);
            action(writer);
            writer.Flush();         
        }
    }
}
