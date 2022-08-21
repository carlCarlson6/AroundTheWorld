using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using MongoDB.Driver;
using MongoRepository.Settings;

namespace MongoRepository.UserRepo
{
    public class UserMongoRepository : IUserRepository
    {
        private readonly IMongoCollection<UserModel> collection;
        public UserMongoRepository(IMongoRepositorySettings<UserModel> settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DatabaseName);
            this.collection = database.GetCollection<UserModel>(settings.CollectionName);
        }

        public async Task<List<User>> Read()
        {
            IAsyncCursor<UserModel> userAsyncCursor = await this.collection.FindAsync(user => true);
            List<UserModel> usersModel = await userAsyncCursor.ToListAsync();

            if(usersModel.Count == 0)
            {
                return new List<User>();
            }

            return usersModel.Select(userModel => new User(new UserId(userModel.id), new Email(userModel.email), new Name(userModel.name), new Password(new EncryptedPassword(userModel.password)))).ToList();
        }

        public async Task<User> Read(UserId id)
        {
            IAsyncCursor<UserModel> userAsyncCursor = await this.collection.FindAsync(user => user.id == id.Value);
            UserModel userFound = await userAsyncCursor.FirstOrDefaultAsync();
            
            if(userFound == null)
            {
                return null;
            }
            
            return new User(new UserId(userFound.id), new Email(userFound.email), new Name(userFound.name), new Password(new EncryptedPassword(userFound.password)));
        }

        public async Task<User> Read(Email email)
        {
            IAsyncCursor<UserModel> userAsyncCursor = await this.collection.FindAsync(user => user.email == email.Value);
            UserModel userFound = await userAsyncCursor.FirstOrDefaultAsync();

            if(userFound == null)
            {
                return null;
            }
                
            return new User(new UserId(userFound.id), new Email(userFound.email), new Name(userFound.name), new Password(new EncryptedPassword(userFound.password)));
        }

        public async Task<int> Save(User user)
        {
            UserModel model = new UserModel(user);
            await this.collection.InsertOneAsync(model);
            return 201;
        }

    }
}