using blog.Infrastructure.Database;
using blog.Infrastructure.Interfaces;
using blog.Infrastructure.Models;
using blog.Infrastructure.Models.Dtos;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace blog.Domain.Repositories
{
    public class CommentRepository : IComment
    {
        private readonly DbContext _mongoDB;
        private readonly IMongoCollection<Comment> _collection;
        public CommentRepository(DbContext connection)
        {
            _mongoDB = connection;
            _collection = _mongoDB.database.GetCollection<Comment>("Comments");
        }
        public Comment Add( CommentDto entity )
        {
            try
            {
                var newComment = new Comment(
                    entity.ArticleId,
                    entity.Text
                );
                _collection.InsertOne(newComment);

                return newComment;

            }catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }

        public bool Delete( string id )
        {
            try
            {
                _collection.UpdateOne(Builders<Comment>.Filter.Eq("Id", ObjectId.Parse(id)), Builders<Comment>.Update.Set("IsDeleted", true));
                return true;
            
            }catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }

        public Comment Edit( string id, CommentDto entity )
        {
            try
            {
                var commentToUpdate = GetById(id);
                if ( commentToUpdate == null )
                {
                    return null;
                }

                _collection.UpdateOne(Builders<Comment>.Filter.Eq("Id", ObjectId.Parse(id)), Builders<Comment>.Update
                    .Set("Text", entity.Text));

                return GetById(id);

            }catch ( Exception ex )
            {
                throw new Exception($"{ex}");
            }
        }

        private Comment GetById( string id )
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
    }
}
