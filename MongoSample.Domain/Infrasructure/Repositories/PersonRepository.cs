using MongoSample.Domain.Infrasructure.Contracts;
using MongoSample.Domain.Models;
using MongoSample.Infrasructure.Contracts;
using MongoSample.Infrasructure.Repositories;

namespace MongoSample.Domain.Infrasructure.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(IMongoContext context) : base(context)
        {
        }
    }
}
