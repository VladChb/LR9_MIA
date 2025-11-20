using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookHubAPI.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("is_checked")]
        public bool IsChecked { get; set; }
    }
}