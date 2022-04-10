using MongoSample.Domain.Models;
using MongoSample.Infrasructure.Contracts;

namespace MongoSample.Domain.Infrasructure.Contracts
{ 
    public interface IPersonRepository : IRepository<Person>
    {
    }
}
