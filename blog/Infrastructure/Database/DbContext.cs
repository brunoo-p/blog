using MongoDB.Driver;
using System;

namespace blog.Infrastructure.Database
{
    public class DbContext
    {
        public IMongoDatabase database;
        public DbContext()
        {
            try
            {
                var client = new MongoClient("mongodb://root:exemple@mongo");
                database = client.GetDatabase("Blog");

            }catch ( Exception ex )
            {
                throw new MongoException("It wasn't possible connect to database", ex);  
            }
        }
    }
}
