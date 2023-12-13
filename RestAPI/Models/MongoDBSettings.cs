namespace RestAPI.Models
{
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string RacerCollectionName { get; set; } = null!;
        public string TagCollectionName { get; set; } = null!;
    }
}
