using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RestAPI.Models
{
    public class Race
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = null!;

        [BsonElement("type")]
        public string Type { get; set; } = null!;

        [BsonElement("townId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TownId { get; set; } = null!;

        [BsonElement("racers")]
        public virtual ICollection<string> RacerIds { get; set; } 
    }
}
