using MongoSample.Domain.Infrasructure.Contracts;
using MongoSample.Infrastructure.Contracts;

namespace MongoSample.Domain.Infrasructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoContext _context;
        IPersonRepository _personRepository;

        public UnitOfWork(IMongoContext context, IPersonRepository personRepository)
        {
            _context = context;
            _personRepository = personRepository;
        }

        public IPersonRepository PersonRepository => _personRepository;

        public async Task<bool> Commit()
        {
            var changeAmount = await _context.SaveChanges();

            return changeAmount > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
