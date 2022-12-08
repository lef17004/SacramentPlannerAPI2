namespace PlannerApi.Models;

public class SacramentPlannerDBSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string ProgramCollectionName { get; set; } = null!;
}