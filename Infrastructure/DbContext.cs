using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StudentManagementAPI.Models;
using System.Reflection;

namespace StudentManagementAPI.Infrastructure
{
    /// <summary>
    /// Mongo db connection context.
    /// </summary>
    public class DbContext
    {
        /// <summary>
        /// Mongo database instance.
        /// </summary>
        private readonly IMongoDatabase mongoDb;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbContext"/> class.
        /// </summary>
        /// <param name="mongoConfiguration">Mongo db configuration.</param>
        public DbContext(IOptions<DatabaseSettings> mongoConfiguration)
        {
            var mongoConfig = mongoConfiguration.Value;

            var mongoSettings = MongoClientSettings.FromConnectionString(mongoConfig.ConnectionString);

            MongoClient = new MongoClient(mongoSettings);
            mongoDb = MongoClient.GetDatabase(mongoConfig.DatabaseName);
        }

        /// <summary>
        /// Gets mongo database client.
        /// </summary>
        public MongoClient MongoClient { get; }

        /// <summary>
        /// Gets databse collection.
        /// </summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <returns>Document collection.</returns>
        public IMongoCollection<T> DbCollection<T>()
        {
            var table = typeof(T).GetCustomAttribute<TableAttribute>().Name;
            return mongoDb.GetCollection<T>(table);
        }
    }
}
