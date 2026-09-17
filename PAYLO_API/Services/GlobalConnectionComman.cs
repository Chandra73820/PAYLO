namespace PAYLO_API.Services
{
    public static class GlobalConnectionComman
    {
        public static string GetGblConnectionString(this IConfiguration config)
        {
            var env = config.GetValue<string>("GBLEnvironment")?.Trim()
                ?? throw new InvalidOperationException("GBLEnvironment is not configured.");

            string key = env.ToUpperInvariant() switch
            {
                "GBLDEV" => "DevConnection",
                "GBLSTAG" => "StagingConnection",
                "GBLLIVE" => "LiveConnection",
                "GBLPROD" => "ProductionConnection",
                _ => throw new InvalidOperationException($"Unknown GBLEnvironment '{env}'.")
            };

            return config.GetSection("GBLConnectionStrings")[key]
                ?? throw new InvalidOperationException($"GBLConnectionStrings:{key} is missing.");
        }
    }
}
