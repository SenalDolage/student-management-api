using StudentManagementAPI.Models;

namespace StudentManagementAPI.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// Filters document by id.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Document of the provided id.</returns>
        Task<TEntity> GetByIdAsync(string id);

        /// <summary>
        /// Returns all documents.
        /// </summary>
        /// <returns>List of all the documents of type.</returns>
        Task<List<TEntity>> GetAll();

    }
}
