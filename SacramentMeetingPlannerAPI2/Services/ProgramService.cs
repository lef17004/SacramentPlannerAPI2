using PlannerApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace PlannerApi.Services;

public class ProgramService
{
    private readonly IMongoCollection<SacramentProgram> _programCollection;

    public ProgramService(
        IOptions<SacramentPlannerDBSettings> plannerDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            plannerDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            plannerDatabaseSettings.Value.DatabaseName);

        _programCollection = mongoDatabase.GetCollection<SacramentProgram>(
            plannerDatabaseSettings.Value.ProgramCollectionName);
    }

    public async Task<List<SacramentProgram>> GetAsync() =>
        await _programCollection.Find(_ => true).ToListAsync();

    public async Task<SacramentProgram?> GetAsync(string id) =>
        await _programCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(SacramentProgram newProgram) =>
        await _programCollection.InsertOneAsync(newProgram);

    public async Task UpdateAsync(string id, SacramentProgram newProgram) =>
        await _programCollection.ReplaceOneAsync(x => x.Id == id, newProgram);

    public async Task RemoveAsync(string id) =>
        await _programCollection.DeleteOneAsync(x => x.Id == id);
}