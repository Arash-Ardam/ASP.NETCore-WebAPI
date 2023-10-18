namespace dotnetcoreWebAPI.Configurations;

public class DbOptions
{
    public bool isInMemory { get; set; }
    public string connectionString { get; set; } = string.Empty;
    public int MaxRetryCount { get; set; }
    public TimeSpan MaxRetryDelay { get; set; }
}
