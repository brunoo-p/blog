using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace blog.Infrastructure.Models
{
    public abstract class Base
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Required]
        [StringLength(24, ErrorMessage = "This ObjectId is not valid")]
        public string Id { get; set; }

        public static bool VerifyLengthId(string id)
        {
            const int NUMBER_CHARACTERS_OBJECTID = 24;
            if (id.Length != NUMBER_CHARACTERS_OBJECTID) {
                return false;
            }
            return true;
        } 
    }
}
