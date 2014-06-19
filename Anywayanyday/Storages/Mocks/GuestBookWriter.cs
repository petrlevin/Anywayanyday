using System;
using Anywayanyday.Model;

namespace Anywayanyday.Storages.Mocks
{
    public class GuestBookWriter: IGuestBookWriter
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Write(Message data)
        {
            throw new NotImplementedException();
        }
    }
}
