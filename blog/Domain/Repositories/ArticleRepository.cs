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
    public class ArticleRepository : IArticle
    {

        private readonly DbContext _mongoDB;
        private readonly IMongoCollection<Article> _collection;
        private readonly IMongoCollection<Comment> _commentsCollection;
        public ArticleRepository( DbContext connection )
        {
            _mongoDB = connection;
            _collection = _mongoDB.database.GetCollection<Article>("Articles");
            _commentsCollection = _mongoDB.database.GetCollection<Comment>("Comments");
        }

        public List<Article> GetAll()
        {
            try
            {
                var articles = new List<Article>();

                var list = _collection.Find(Builders<Article>.Filter
                    .Where(_ => _.IsDeleted == false))
                    .SortBy(_ => _.Title)
                    .ToList();

                foreach ( var article in list )
                {
                    var comments = ListComments(article.Id);
                    articles.Add(
                        new Article(
                            article.Id,
                            article.AuthorId,
                            article.Title,
                            article.Description,
                            article.Text,
                            article.CategoryName,
                            comments
                        )
                    );
                }
                return articles;
            }
            catch ( Exception ex )
            {
                throw new Exception($"Error: {ex}");
            }
        }
        public Article Add( ArticleDto entity )
        {
            try
            {
                var article = new Article(
                    entity.AuthorId,
                    entity.Title,
                    entity.Description,
                    entity.Text,
                    entity.CategoryName
                );

                _collection.InsertOne(article);

                return article;

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

                _collection.UpdateOne(Builders<Article>.Filter.Eq("Id", ObjectId.Parse(id)), Builders<Article>.Update.Set("IsDeleted", true));
                return true;
            }
            catch ( Exception ex )
            {
                return false;
            }
        }

        public Article Edit( string id, ArticleDto entity )
        {
            try
            {
                var articleToUpdate = GetById(id);
                if ( articleToUpdate == null )
                {
                    return null;
                }

                _collection.UpdateOne(Builders<Article>.Filter.Eq("Id", ObjectId.Parse(id)), Builders<Article>.Update
                    .Set("Title", entity.Title)
                    .Set("Description", entity.Description)
                    .Set("Text", entity.Text)
                );

                return GetById(id);

            }
            catch ( Exception ex )
            {
                throw new Exception($"{ex}");
            }
        }

        public Article GetById( string id )
        {
            try
            {
                var article = _collection.Find(_ => _.Id == id && _.IsDeleted == false).FirstOrDefault();
                var comments = ListComments(id);

                return new Article(
                    article.Id,
                    article.AuthorId,
                    article.Title,
                    article.Description,
                    article.Text,
                    article.CategoryName,
                    comments
                );
            }
            catch ( Exception ex )
            {
                throw new Exception($"{ex}");
            }
        }

        public Article UpdateCategoryName(string id, CategoryDto category)
        {
            try
            {
                var articleToUpdate = GetById(id);
                if ( articleToUpdate == null )
                {
                    return null;
                }
                _collection.UpdateOne(Builders<Article>.Filter.Eq("Id", ObjectId.Parse(id)), Builders<Article>.Update
                    .Set("CategoryName", category.Name));
            
                return GetById(id);
            
            }
            catch ( Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }

        private bool ConfirmIsNotDeleted( string id )
        {
            try
            {
                var exist = _collection.Find(Builders<Article>.Filter.Where(_ => _.Id == id && _.IsDeleted == false));

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
        private List<Comment> ListComments(string id)
        {
            try
            {
                return _commentsCollection.Find(_ => _.ArticleId == id && _.IsDeleted == false).ToList();
            
            }catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }

    }
}
