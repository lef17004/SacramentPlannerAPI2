using PlannerApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace PlannerApi.Services;

public class SpeakerNameService
{
    private readonly IMongoCollection<SpeakerName> _speakerNameCollection;

    public SpeakerNameService(
        IOptions<SpeakerNameDBSettings> speakerNameDBSettings)
    {
        var mongoClient = new MongoClient(
            speakerNameDBSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            speakerNameDBSettings.Value.DatabaseName);

        _speakerNameCollection = mongoDatabase.GetCollection<SpeakerName>(
            speakerNameDBSettings.Value.SpeakerCollectionName);
    }

    public async Task<List<SpeakerName>> GetAsync() =>
        await _speakerNameCollection.Find(_ => true).ToListAsync();

    public async Task<SpeakerName?> GetAsync(string id) =>
        await _speakerNameCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(SpeakerName newName) =>
        await _speakerNameCollection.InsertOneAsync(newName);

    public async Task UpdateAsync(string id, SpeakerName newSpeaker) =>
        await _speakerNameCollection.ReplaceOneAsync(x => x.Id == id, newSpeaker);

    public async Task RemoveAsync(string id) =>
        await _speakerNameCollection.DeleteOneAsync(x => x.Id == id);
}