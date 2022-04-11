using MongoSample.Domain.Infrasructure.Contracts;
using MongoSample.Domain.Models;
using MongoSample.Infrastructure.Contracts;
using MongoSample.Infrastructure.Repositories;

namespace MongoSample.Domain.Infrasructure.Repositories
{
    public class PersonRepository : MongoDBRepository<Person>, IPersonRepository
    {
        public PersonRepository(IMongoContext context) : base(context)
        {
        }
    }
}
