using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PlannerApi.Models;

public class SpeakerName
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public String Name { get; set; }
}