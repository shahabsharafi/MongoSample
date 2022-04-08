using MongoSample.Infrasructure.Contracts;
using MongoSample.Domains.EmployeeDomain.Models;

namespace MongoSample.Infrasructure.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(IMongoContext context) : base(context)
        {
        }
    }
}
