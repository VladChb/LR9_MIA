using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookHubAPI.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }= string.Empty;

        [BsonElement("title")]
        public string Title { get; set; }= string.Empty;

        [BsonElement("authorId")]
        public int AuthorId { get; set; }

        [BsonElement("year")]
        public int Year { get; set; }

    }
}
