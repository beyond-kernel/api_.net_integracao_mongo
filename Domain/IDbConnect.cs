using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IDbConnect
    {
        public IMongoDatabase Connect();
    }
}
