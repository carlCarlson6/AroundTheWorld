using System;

namespace MongoRepository.Settings
{
    public interface IMongoRepositorySettings<T>
    {
        String CollectionName { get; set; }
        String ConnectionString { get; set; }
        String DatabaseName { get; set; }
    }
}