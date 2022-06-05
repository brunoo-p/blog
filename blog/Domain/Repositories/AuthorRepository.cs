using blog.Infrastructure.Database;
using blog.Infrastructure.Interfaces;
using blog.Infrastructure.Models;
using blog.Infrastructure.Models.Dtos;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace blog.Domain.Repositories
{
    public class AuthorRepository : IAuthor
    {
        private readonly DbContext _mongoDB;
        private readonly IMongoCollection<Author> _collection;
        private readonly IMongoCollection<Article> _articleCollection;
        public AuthorRepository( DbContext connection )
        {
            _mongoDB = connection;
            _collection = _mongoDB.database.GetCollection<Author>("Authors");
            _articleCollection = _mongoDB.database.GetCollection<Article>("Articles");
        }

        public List<Author> GetAll()
        {
            try
            {
                return _collection.Find(Builders<Author>.Filter
                    .Where(_ => _.IsDeleted == false))
                    .SortBy(_ => _.FirstName)
                    .ToList();

            }
            catch ( Exception ex )
            {
                throw new Exception($"Error: {ex}");
            }
        }
        public Author Add( AuthorDto entity )
        {
            try
            {
                var author = new Author(
                    entity.FirstName,
                    entity.LastName,
                    entity.Age,
                    entity.Email
                );

                _collection.InsertOne(author);
                return _collection.Find(Builders<Author>.Filter.Where(_ => _.Email == author.Email)).FirstOrDefault();

            }
            catch ( Exception ex )
            {
                throw new Exception($"{ex}");
            }

        }

        public bool Delete( string id )
        {
            try
            {
                bool existInCollection = ConfirmIsNotDeleted(id);
                if ( !existInCollection )
                {
                    return false;
                }

                // flag exclude author
                _collection.UpdateOne(Builders<Author>.Filter.Eq("Id", ObjectId.Parse(id)), Builders<Author>.Update.Set("IsDeleted", true));
                // flag exclude articles linked to author id
                _articleCollection.UpdateOne(Builders<Article>.Filter.Eq("AuthorId", ObjectId.Parse(id)), Builders<Article>.Update.Set("IsDeleted", true));

                return true;

            }
            catch ( Exception ex )
            {
                throw new Exception($"{ex}");
            }
        }

        public Author Edit( string id, AuthorDto entity )
        {
            try
            {
                var authorToUpdate = GetById(id);
                if ( authorToUpdate == null )
                {
                    return null;
                }

                _collection.UpdateOne(Builders<Author>.Filter.Eq("Id", ObjectId.Parse(id)), Builders<Author>.Update
                    .Set("FirstName", entity.FirstName)
                    .Set("LastName", entity.LastName)
                    .Set("Age", entity.Age)
                    .Set("Email", entity.Email)
                );

                return GetById(id);

            }
            catch ( Exception ex )
            {
                throw new Exception($"{ex}");
            }
        }

        public Author GetById( string id )
        {
            try
            {
                return _collection.Find(_ => _.Id == id && _.IsDeleted == false).FirstOrDefault();
                    
            }
            catch ( Exception ex )
            {
                throw new Exception($"{ex}");
            }
        }


        private bool ConfirmIsNotDeleted( string id )
        {
            try
            {
                var exist = _collection.Find(Builders<Author>.Filter.Where(_ => _.Id == id && _.IsDeleted == false));

                if ( exist == null )
                {
                    return false;
                }

                return true;
            }
            catch
            {
                throw new MongoException("Isn't possible to access collection");
            }
        }
    }
}
