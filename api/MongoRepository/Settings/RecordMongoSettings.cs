using System;
using MongoRepository.RecordRepro;

namespace MongoRepository.Settings
{
    public class RecordMongoSettings : IMongoRepositorySettings<RecordModel>
    {
        public String CollectionName { get; set; }
        public String ConnectionString { get; set; }
        public String DatabaseName { get; set; }
    }
}
