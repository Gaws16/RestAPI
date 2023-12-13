using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RestAPI.Models
{
    public class Chip
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("tagUId")]
        [BsonRequired]
        public string ChipUId { get; set; } = null!;
    }
}
