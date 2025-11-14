using Microsoft.Data.SqlClient;

namespace API.Config;

public static class DatabaseSettings
{
    public static string GetConnectionString(IConfiguration configuration)
    {
        var connString = new SqlConnectionStringBuilder
        {
            DataSource = configuration["DB_HOST"],
            InitialCatalog = configuration["DB_NAME"],
            UserID = configuration["DB_USER"],
            Password = configuration["DB_PASSWORD"],
            Encrypt = bool.Parse(configuration["DB_ENCRYPT"] ?? "true"),
            TrustServerCertificate
            = bool.Parse(configuration["DB_TRUST_SERVER_CERTIFICATE"] ?? "true"),
        }.ConnectionString;

        return connString;
    }
}
