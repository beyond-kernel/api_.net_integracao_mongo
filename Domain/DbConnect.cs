using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class DbConnect : IDbConnect
    {
        public IMongoDatabase Connect()
        {
            var client = new MongoClient(
                   "mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false"
               );

            return client.GetDatabase("pokemon_center");
        }
    }
}
