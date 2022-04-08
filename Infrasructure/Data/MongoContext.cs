
using Microsoft.Extensions.Options;
using MongoSample.Infrasructure.Contracts;
using MongoDB.Driver;

namespace MongoSample.Infrasructure.Data
{
    public class MongoContext : IMongoContext
    {
        public IClientSessionHandle? Session { get; set; }
        public MongoClient MongoClient { get; set; }
        private IMongoDatabase _database { get; set; }
        private readonly List<Func<Task>> _commands;

        public MongoContext(IOptions<ConnectionSettings> options)
        {
            MongoUrl url = MongoUrl.Create(options.Value.MongoConnection);
            MongoClient = new MongoClient(url);
            _database = MongoClient.GetDatabase(url.DatabaseName);

            // Every command will be stored and it'll be processed at SaveChanges
            _commands = new List<Func<Task>>();
        }

        public async Task<int> SaveChanges()
        {
            using (Session = await MongoClient.StartSessionAsync())
            {
                Session.StartTransaction();

                var commandTasks = _commands.Select(c => c());

                await Task.WhenAll(commandTasks);

                await Session.CommitTransactionAsync();
            }

            return _commands.Count;
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }

        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }

        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }
    }
}
