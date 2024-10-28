using Microsoft.Extensions.Options;
using MongoDB.Driver;
using VulcanoTest.Data;
using VulcanoTest.Models;

namespace VulcanoTest.Infraestructura.Data
{
    public class DatabaseContext
    {
        private readonly IMongoDatabase _database;

        public DatabaseContext(IOptions<DatabaseSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Product> Products => _database.GetCollection<Product>("Productos");
    }
}