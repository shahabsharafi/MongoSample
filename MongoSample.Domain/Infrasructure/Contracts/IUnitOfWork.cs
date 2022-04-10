namespace MongoSample.Domain.Infrasructure.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
        IPersonRepository PersonRepository { get; } 
    }
}
