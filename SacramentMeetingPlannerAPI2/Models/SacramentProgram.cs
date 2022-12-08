using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PlannerApi.Models;

public class SacramentProgram
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Date")]
    public string Date { get; set; } = null!;
    public string Presiding { get; set; } = null!;
    public string Conducting { get; set; } = null!;
    public int OpeningHymnNumber { get; set; }
    public string OpeningHymnName { get; set; } = null!;
    public string OpeningPrayer { get; set; } = null!;
    public int SacramentHymnNumber { get; set; }
    public string SacramentHymnName { get; set; } = null!;

    public List<Dictionary<String, Object>> Speakers { get; set; } = null!;
    public int ClosingHymnNumber { get; set; }
    public string ClosingHymnName { get; set; } = null!;

    public string ClosingPrayer { get; set; } = null!;

    public int DismissalHymnNumber { get; set; }
    public string DismissalHymnName { get; set; } = null!;
}