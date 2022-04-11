using MongoSample.Infrastructure.Contracts;
using MongoDB.Bson;
using MongoDB.Driver;
namespace MongoSample.Infrastructure.Repositories
{
    public abstract class MongoDBRepository<TEntity> : BaseRepository<TEntity>, IMongoDBRepository<TEntity> 
        where TEntity : class, IEntity
    {
        protected MongoDBRepository(IMongoContext context) : base(context)
        {
        }

        public IMongoCollection<TEntity> DbSet
        {
            get { return _dbSet; }
        }
    }
}
