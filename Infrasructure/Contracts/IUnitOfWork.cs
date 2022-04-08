namespace MongoSample.Infrasructure.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
        IPersonRepository PersonRepository { get; } 
    }
}
