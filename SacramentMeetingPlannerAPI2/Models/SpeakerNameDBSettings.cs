namespace PlannerApi.Models;

public class SpeakerNameDBSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string SpeakerCollectionName { get; set; } = null!;
}