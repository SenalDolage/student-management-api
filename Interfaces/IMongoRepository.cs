using StudentManagementAPI.Models;
using System.Linq.Expressions;

namespace StudentManagementAPI.Interfaces
{
    public interface IMongoRepository<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// Returns all documents.
        /// </summary>
        /// <param name="ct">Cancellation token.</param>
        /// <param name="excludedFields">Fields to exclude.</param>
        /// <returns>List of all the documents of type.</returns>
        Task<List<TEntity>> GetAll(CancellationToken ct = default, params Expression<Func<TEntity, object>>[] excludedFields);

        /// <summary>
        /// Filters document by id.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <param name="excludedFields">Fields to exclude.</param>
        /// <returns>Document of the provided id.</returns>
        Task<TEntity> GetByIdAsync(object id, CancellationToken ct = default, params Expression<Func<TEntity, object>>[] excludedFields);

        /// <summary>
        /// Counts the documents.
        /// </summary>
        /// <param name="filter">The filter. Accepts Expression.</param>
        /// <param name="ct">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;System.Int64&gt;.</returns>
        Task<long> CountAsync(Expression<Func<TEntity, bool>> filter, CancellationToken ct = default);


        /// <summary>
        /// Creates a new document.
        /// </summary>
        /// <param name="model">Model to create the document.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task CreateAsync(TEntity model, CancellationToken ct = default);

        /// <summary>
        /// Deleted document by given id.
        /// </summary>
        /// <param name="id">Id to delete.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation with the result of the delete operation.</returns>
        Task<bool> DeleteAsync(string id, CancellationToken ct = default);

        /// <summary>
        /// Replaces given document.
        /// </summary>
        /// <param name="model">Model to replace the document from.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation with the updated document.</returns>
        Task<TEntity> UpdateAsync(TEntity model, CancellationToken ct = default);
    }
}
