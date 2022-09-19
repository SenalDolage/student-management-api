using MongoDB.Bson;
using MongoDB.Driver;
using StudentManagementAPI.Infrastructure;
using StudentManagementAPI.Interfaces;
using StudentManagementAPI.Models;
using System.Linq.Expressions;

namespace StudentManagementAPI.Repositories
{
    public class MongoRepository<TEntity> : IMongoRepository<TEntity> where TEntity : Entity
    {
        private readonly DbContext dbContext;
        private IMongoCollection<TEntity> collection;
        private readonly IClientSessionHandle session;


        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="session"></param>
        public MongoRepository(DbContext dbContext, IClientSessionHandle session)
        {
            this.dbContext = dbContext;
            this.session = session;
        }

        /// <summary>
        /// Gets database collection.
        /// </summary>
        private IMongoCollection<TEntity> Collection
        {
            get { return this.collection ??= this.dbContext.DbCollection<TEntity>(); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public Task<long> CountAsync(Expression<Func<TEntity, bool>> filter, CancellationToken ct = default)
        {
            return Collection.CountDocumentsAsync(this.session, filter, cancellationToken: ct);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public Task CreateAsync(TEntity model, CancellationToken ct = default)
        {
            model.CreatedDate = DateTime.Now;
            model.ChangedDate = DateTime.Now;
            return Collection.InsertOneAsync(this.session, model, cancellationToken: ct);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(string id, CancellationToken ct = default)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                return false;
            }

            var filterId = Builders<TEntity>.Filter.Eq("_id", objectId);
            var deleted = await Collection.FindOneAndDeleteAsync(this.session, filterId, cancellationToken: ct);
            return deleted != null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="excludedFields"></param>
        /// <returns></returns>
        public Task<List<TEntity>> GetAll(CancellationToken ct = default, params Expression<Func<TEntity, object>>[] excludedFields)
        {
            return this.Collection.Find(session, FilterDefinition<TEntity>.Empty).ToListAsync(ct);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <param name="excludedFields"></param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public Task<TEntity> GetByIdAsync(object id, CancellationToken ct = default, params Expression<Func<TEntity, object>>[] excludedFields)
        {
            if (!ObjectId.TryParse(id.ToString(), out var objectId))
            {
                throw new InvalidDataException();
            }

            var filterId = Builders<TEntity>.Filter.Eq("_id", objectId);
            return this.Collection.Find(session, filterId).FirstOrDefaultAsync(ct);
        }

        /// <summary>
        /// Replaces given document.
        /// </summary>
        /// <param name="model">Model to replace the document from.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing the asynchronous operation with the updated document.</returns>
        public virtual Task<TEntity> UpdateAsync(TEntity model, CancellationToken ct = default)
        {
            model.ChangedDate = DateTime.Now;
            var filterId = Builders<TEntity>.Filter.Eq("_id", ObjectId.Parse(model.Id));
            var options = new FindOneAndReplaceOptions<TEntity>
            {
                ReturnDocument = ReturnDocument.After,
            };

            return this.Collection.FindOneAndReplaceAsync(this.session, filterId, model, options, cancellationToken: ct);
        }
    }
}