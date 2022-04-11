using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoSample.Infrastructure.Contracts
{
    public interface IMongoDBRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public IMongoCollection<TEntity> DbSet { get; }
    }
}
