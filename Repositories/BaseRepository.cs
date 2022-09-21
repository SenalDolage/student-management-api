using MongoDB.Driver;
using StudentManagementAPI.Infrastructure;
using StudentManagementAPI.Interfaces;
using StudentManagementAPI.Models;
using System.Linq.Expressions;

namespace StudentManagementAPI.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// The mongo repository.
        /// </summary>
        private readonly IMongoCollection<TEntity> _dbCollection;

        public BaseRepository(string collection, IMongoDatabase mongoDatabase)
        {
            Collection = collection;
            _dbCollection = mongoDatabase.GetCollection<TEntity>(Collection);
        }

        public string Collection { get; }

        /// <summary>
        /// get by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Document of the provided id.</returns>
        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await _dbCollection.Find(_ => _.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Returns all documents.
        /// </summary>
        /// <returns>List of all the documents of type.</returns>
        public async Task<List<TEntity>> GetAll()
        {
            return await _dbCollection.Find(_ => true).ToListAsync();
        }

        /// <summary>
        /// Counts the documents.
        /// </summary>
        /// <returns>Task&lt;System.Int64&gt;.</returns>
        public async Task<long> CountAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbCollection.CountAsync(filter);
        }

        /// <summary>
        /// Creates a new document.
        /// </summary>
        /// <param name="model">Model to create the document.</param>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing the asynchronous operation.</returns>
        public async Task<TEntity> CreateAsync(TEntity model)
        {
            await _dbCollection.InsertOneAsync(model);
            return model;
        }

        /// <summary>
        /// Delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">Id to delete.</param>
        /// <returns>The asynchronous operation with the result of the delete operation.</returns>
        public async Task<bool> DeleteAsync(string id)
        {
            await _dbCollection.FindOneAndDeleteAsync(id);
            return true;
        }

        /// <summary>
        /// Replaces given document.
        /// </summary>
        /// <param name="model">Model to replace the document from.</param>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing the asynchronous operation with the updated document.</returns>
        public async Task<TEntity> UpdateAsync(TEntity model)
        {
            await _dbCollection.FindOneAndReplaceAsync(model.Id, model);
            return model;
        }
    }
}
