using MongoSample.Domain.Models;
using MongoSample.Infrastructure.Contracts;

namespace MongoSample.Domain.Infrasructure.Contracts
{ 
    public interface IPersonRepository : IMongoDBRepository<Person>
    {
    }
}
