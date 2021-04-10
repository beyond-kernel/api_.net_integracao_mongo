using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace pokedex_api
{
    public interface IDbConnect
    {
        public IMongoDatabase Connect();
    }
}
