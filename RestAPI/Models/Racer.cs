using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace RestAPI.Models
{
    public class Racer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("number")]
        [BsonRequired]
        public string Number { get; set; } = null!;
        [BsonElement("firstName")]
        [BsonRequired]
        public string FirstName { get; set; } = null!;
        [BsonElement("lastName")]
        [BsonRequired]
        public string LastName { get; set; } = null!;

        [BsonElement("nationality")]
        public string Nationality { get; set; } = null!;

        [BsonElement("team")]
        public string Team { get; set; } = null!;

        [BsonElement("age")]
        [BsonRequired]
        public int Age { get; set; }

        [BsonElement("gender")]
        [BsonRequired]
        public string Gender { get; set; } = null!;

        [BsonElement("time")]
        public TimeSpan Time { get; set; }

        //[BsonElement("items")]
        //[JsonPropertyName("items")]
        //public List<string> racesIds { get; set; } = null!;
    }
}
