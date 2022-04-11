using Microsoft.Extensions.Caching.Memory;
using MongoDB.Driver;
using MongoSample.Domain.Infrasructure.Contracts;
using MongoSample.Domain.Models;

namespace MongoSample.Domain.Infrasructure
{
    public class IndexManager : IIndexManager
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IUnitOfWork _unitOfWork;
        public IndexManager(IMemoryCache memoryCache, IUnitOfWork unitOfWork)
        {
            _memoryCache = memoryCache;
            _unitOfWork = unitOfWork;
        }

        public void SendIndexInfo(string[] indexes)
        {
            string currentIndex = string.Join(",", indexes);
            string lastIndex = "";
            _memoryCache.TryGetValue("last_index", out lastIndex);
            if (currentIndex == lastIndex)
            {
                _memoryCache.Set("next_index", "");
                _memoryCache.Set("repeat_index", 0);
            }
            else
            {
                string nextIndex = "";
                _memoryCache.TryGetValue("next_index", out nextIndex);
                if (currentIndex == nextIndex)
                {
                    int repeatIndex = 0;
                    _memoryCache.TryGetValue<int>("repeat_index", out repeatIndex);
                    repeatIndex++;
                    if (repeatIndex > 5)
                    {
                        _memoryCache.Set("last_index", currentIndex);
                        _memoryCache.Set("next_index", "");
                        _memoryCache.Set("repeat_index", 0);

                        var indexString = "{ " + string.Join(",", currentIndex.Split(",").Select(o => $"{o}: 1")) + " }";
                        IndexKeysDefinition<Person> indexKeys = indexString;
                        CreateIndexModel<Person> createIndexModel = new CreateIndexModel<Person>(indexKeys);
                        _unitOfWork.PersonRepository.DbSet.Indexes.CreateOneAsync(createIndexModel);
                    }
                    else
                    {
                        _memoryCache.Set("repeat_index", repeatIndex);
                    }
                }
                else
                {
                    _memoryCache.Set("next_index", currentIndex);
                    _memoryCache.Set("repeat_index", 0);
                }
            }
        }
    }
}
