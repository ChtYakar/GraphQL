using GraphQL_Nsn.Interfaces;
using GraphQL_Nsn.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Nsn.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T:BaseEntity
    {
        private IMongoClient _client;
        private IMongoDatabase _db;
        private readonly IMongoCollection<T> _collection;
        public GenericRepository()
        {
            var path = Directory.GetCurrentDirectory();

            var configuration = new ConfigurationBuilder().
                SetBasePath(path)
                .AddJsonFile($"appsettings.Development.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration["MongoConnectionString"];

            _client = new MongoClient(connectionString);
            _db = _client.GetDatabase("LIVESCORE");
            _collection = _db.GetCollection<T>(typeof(T).Name);
        }
        public void Delete(int id)
        {
            _collection.DeleteOne<T>(x => x.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            var filter = Builders<T>.Filter.Empty;
            return _collection.Find<T>(filter).ToList();
        }

        public T GetById(int id)
        {
            var filter = Builders<T>.Filter.Where(x => x.Id == id);
            return _collection.Find<T>(filter).FirstOrDefault();
        }

        public T Insert(T entity)
        {
            _collection.InsertOne(entity);
            return entity;
        }

        public T Update(T entity)
        {
            var updateQuery = Builders<T>.Filter.Eq("Id", entity.Id);
            _collection.ReplaceOne(updateQuery, entity);
            return entity;
        }
    }
}
