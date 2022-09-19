using MongoDB.Driver;
using StudentManagementAPI.Infrastructure;
using StudentManagementAPI.Interfaces;
using StudentManagementAPI.Models;
using System.Linq.Expressions;

namespace StudentManagementAPI.Repositories
{
    public class BaseRepository<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// The mongo repository.
        /// </summary>
        private readonly IMongoRepository<TEntity> repository;

        public BaseRepository(IServiceProvider serviceProvider)
        {
            var mongoDbContext = serviceProvider.GetRequiredService<DbContext>();
            var mongoDbSession = serviceProvider.GetRequiredService<IClientSessionHandle>();

            repository = new MongoRepository<TEntity>(mongoDbContext, mongoDbSession);
        }

        /// <summary>
        /// get by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <param name="excludedFields">Excluded Fields.</param>
        /// <returns>Document of the provided id.</returns>
        /// <exception cref="InvalidDataException">Invalid id.</exception>
        protected virtual Task<TEntity> GetByIdAsync(object id, CancellationToken ct = default, params Expression<Func<TEntity, object>>[] excludedFields)
        {
            return repository.GetByIdAsync(id, ct, excludedFields);
        }

        /// <summary>
        /// Returns all documents.
        /// </summary>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>List of all the documents of type.</returns>
        protected virtual Task<List<TEntity>> GetAll(CancellationToken ct = default)
        {
            return repository.GetAll(ct);
        }

        /// <summary>
        /// Counts the documents.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="ct">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;System.Int64&gt;.</returns>
        protected virtual Task<long> CountAsync(Expression<Func<TEntity, bool>> filter, CancellationToken ct = default)
        {
            return repository.CountAsync(filter, ct);
        }

        /// <summary>
        /// Creates a new document.
        /// </summary>
        /// <param name="model">Model to create the document.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing the asynchronous operation.</returns>
        protected virtual Task CreateAsync(TEntity model, CancellationToken ct = default)
        {
            return repository.CreateAsync(model, ct);
        }

        /// <summary>
        /// Delete as an asynchronous operation.
        /// </summary>
        /// <param name="id">Id to delete.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing the asynchronous operation with the result of the delete operation.</returns>
        protected virtual Task<bool> DeleteAsync(string id, CancellationToken ct = default)
        {
            return repository.DeleteAsync(id, ct);
        }

        /// <summary>
        /// Replaces given document.
        /// </summary>
        /// <param name="model">Model to replace the document from.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing the asynchronous operation with the updated document.</returns>
        protected virtual Task<TEntity> UpdateAsync(TEntity model, CancellationToken ct = default)
        {
            return repository.UpdateAsync(model, ct);
        }
    }
}
