using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookHubAPI.Models
{
    public class Member
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }= string.Empty;

        [BsonElement("name")]
        public string Name { get; set; }= string.Empty;

        [BsonElement("email")]
        public string Email { get; set; }= string.Empty;

        [BsonElement("password")]
        public string Password { get; set; } = string.Empty;
        
        [BsonElement("role")]
        public MemberRole Role { get; set; }

        //public MemberRole Role { get; set; } = MemberRole.Reader;
    }
}
