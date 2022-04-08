using MongoSample.Domains.EmployeeDomain.Models;

namespace MongoSample.Infrasructure.Contracts
{ 
    public interface IPersonRepository : IRepository<Person>
    {
    }
}
