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
    public class CategoryRepository : ICategory
    {
        private readonly DbContext _mongoDB;
        private readonly IMongoCollection<Category> _collection;
        private readonly IMongoCollection<Article> _articleCollection;

        public CategoryRepository(DbContext connection)
        {
            _mongoDB = connection;
            _collection = _mongoDB.database.GetCollection<Category>("Categories");
            _articleCollection = _mongoDB.database.GetCollection<Article>("Article");
        }

        public List<Category> GetAll()
        {
            return _collection.Find(Builders<Category>.Filter
                        .Where(_ => _.IsDeleted == false))
                        .SortBy(_ => _.Type)
                        .ToList();
        }
        public Category Add( CategoryDto entity )
        {
            try
            {
                var category = new Category(
                    entity.Name,
                    entity.Type
                );
                _collection.InsertOne(category);
                
                return category;

            } catch ( Exception ex )
            {
                throw new Exception($"{ex}");
            }
        }

        public bool Delete( string id )
        {
            try
            {
                _collection.UpdateOne(Builders<Category>.Filter.Eq("Id", ObjectId.Parse(id)), Builders<Category>.Update.Set("IsDeleted", true));
                return true;

            }catch(Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }

        public Category Edit( string id, CategoryDto entity )
        {
            var categoryToUpdate = GetById(id);
            if ( categoryToUpdate == null )
            {
                return null;
            }

            _collection.UpdateOne(Builders<Category>.Filter.Eq("Id", ObjectId.Parse(id)), Builders<Category>.Update
                .Set("Name", entity.Name)
                .Set("Type", entity.Type)
            );

            return GetById(id);
        }

        public List<Article> GetAllArticleByCategory( string name )
        {
            try
            {
                return _articleCollection.Find(_ => _.CategoryName == name && _.IsDeleted == false).ToList();    

            }catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }

        private Category GetById( string id )
        {
            try
            {
                return _collection.Find(_ => _.IsDeleted == false).FirstOrDefault();
            }
            catch ( Exception ex )
            {
                throw new Exception($"{ex}");
            }
        }
    }
}
