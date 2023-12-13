using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using RestAPI.Models;

namespace RestAPI.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<Racer> _racersCollection;
        private readonly IMongoCollection<Chip> _chipsCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _racersCollection = database.GetCollection<Racer>(mongoDBSettings.Value.RacerCollectionName);
            _chipsCollection = database.GetCollection<Chip>(mongoDBSettings.Value.TagCollectionName);

        }

        public async Task CreateAsync(Racer racer)
        {
            
            await _racersCollection.InsertOneAsync(racer);
            return;
        }
        public async Task CreateChipAsync(Chip chip)
        {

            await _chipsCollection.InsertOneAsync(chip);
            return;
        }

        public async Task<List<Racer>> GetAsync()
        {
            return await _racersCollection.Find(new BsonDocument()).ToListAsync();

        }
        public async Task<List<Chip>> GetChipAsync()
        {
            return await _chipsCollection.Find(new BsonDocument()).ToListAsync();

        }

        public async Task AddChipAsync(string id,string chipId)
        {
            FilterDefinition<Chip> filter = Builders<Chip>.Filter.Eq("Id", id);
            UpdateDefinition<Chip> update = Builders<Chip>.Update.AddToSet<string>("chipId", chipId);
            await _chipsCollection.UpdateOneAsync(filter, update);
        }
        public async Task AddRacerAsync(string id, string raceId)
        {
            FilterDefinition<Racer> filter = Builders<Racer>.Filter.Eq("Id", id);
            UpdateDefinition<Racer> update = Builders<Racer>.Update.AddToSet<string>("raceId", raceId);
            await _racersCollection.UpdateOneAsync(filter, update);

        }

        public async Task DeleteAsync(string id)
        {
            FilterDefinition<Racer> filter = Builders<Racer>.Filter.Eq("Id", id);
            await _racersCollection.DeleteOneAsync(filter);
        }
    }
}
