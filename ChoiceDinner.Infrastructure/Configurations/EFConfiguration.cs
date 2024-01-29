namespace ChoiceDinner.Infrastructure.Configurations;

public class EFConfiguration
{
    public int CommandTimeout { get; set; }
    public bool EnableSensitiveDataLogging { get; set; }
    public bool EnableDetailedErrors { get; set; }
}